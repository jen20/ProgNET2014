using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex9
{
    public class TestDataSource
    {
        public async Task<IEnumerable<TestModel>> GetTests()
        {
            await Task.Delay(2000);
            return GetModels();
        }

        private IEnumerable<TestModel> GetModels()
        {
            return Enumerable.Range(0, 10).Select(number => new TestModel { Id = number, Name = "Model Number " + number });
        }
    }
}