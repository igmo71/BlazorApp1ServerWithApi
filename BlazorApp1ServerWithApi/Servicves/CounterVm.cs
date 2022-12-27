namespace BlazorApp1ServerWithApi.Servicves
{
    public class CounterVm
    {
        public int Count { get; set; }
        public int CurrentCount { get; set; }

        public static CounterVmBuilder CreateBuilder()
        {
            return new CounterVmBuilder();
        }
    }

    public class CounterVmBuilder
    {
        private CounterVm counterVm;

        public CounterVmBuilder()
        {
            counterVm = new CounterVm();
        }

        public CounterVmBuilder SetCount(int count)
        {
            counterVm.Count = count;
            counterVm.CurrentCount += count;            
            return this;
        }

        public CounterVm Build()
        {
            return counterVm;
        }
    }
}
