using System;
using System.Collections.Generic;
using ReactiveUI;

namespace Ex9
{
    public class MainWindowModel : ReactiveObject
    {
        private readonly TestDataSource _testDataSource;

        public MainWindowModel()
        {
            _testDataSource = new TestDataSource();
            TestModels = new ReactiveList<TestModel>();

            TestViewModels = TestModels.CreateDerivedCollection(m =>
            {
                var vm = new TestViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    OtherValue = "",
                    OriginalModel = m
                };
                vm.DoStuffWithThisCommand.Subscribe(x => DoStuff(x as TestViewModel));
                return vm;
            }, m => true, (m, vm) => 0);

            SetUpDataCommand = ReactiveCommand.CreateAsyncTask(_ => _testDataSource.GetTests());
            SetUpDataCommand.Subscribe(results =>
                {
                    using (SuppressChangeNotifications())
                    {
                        TestModels.Clear();
                        foreach (var model in results)
                            TestModels.Add(model);
                    }
                });
        }

        private void DoStuff(TestViewModel vm)
        {
            TestModels.Remove(vm.OriginalModel);
        }

        public IReactiveDerivedList<TestViewModel> TestViewModels { get; private set; } 

        public ReactiveList<TestModel> TestModels { get; private set; } 

        public ReactiveCommand<IEnumerable<TestModel>> SetUpDataCommand { get; private set; }
    }
}