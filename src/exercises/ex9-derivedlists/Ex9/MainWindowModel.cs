using System;
using ReactiveUI;

namespace Ex9
{
    public class MainWindowModel : ReactiveObject
    {
        private TestViewModel CreateTestViewModelFromTestModel(TestModel m)
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
        }

        private readonly TestDataSource _testDataSource;

        public MainWindowModel()
        {
            _testDataSource = new TestDataSource();
            TestModels = new ReactiveList<TestModel>();

            //TODO: Add code that declares a derviced collection which uses `CreateTestViewModelFromTestModel`
            //      as it's conversion, uses `true` as it's filter and 0 as the ordering function

            //TODO: Move the `CreateTestViewModelFromTestModel` function into a lambda


            SetUpDataCommand = new ReactiveCommand();
            SetUpDataCommand.RegisterAsyncTask(_ => _testDataSource.GetTests())
                .Subscribe(results =>
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

        public IReactiveCommand SetUpDataCommand { get; private set; }
    }
}