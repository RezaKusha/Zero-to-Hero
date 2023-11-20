using System;

namespace Homework3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MacFactory mac = new MacFactory();
            WindowsFactory win = new WindowsFactory();
            
            win.InstallCooler();
            mac.PrepareBody();
        }
    }

    public abstract class MainFactory
    {
        public abstract void PrepareBody();
        public abstract void InstallCPU();
        public abstract void InstallRAM();
        public abstract void InstallGPU();
        public abstract void InstallCooler();
        public abstract void InstallMotherboard();
    }

    public class WindowsFactory : MainFactory
    {
        public override void PrepareBody()
        {
            Console.WriteLine("Win Body Preparing");
        }
        public override void InstallCPU()
        {
            Console.WriteLine("Installing Win CPU");
        }
        public override void InstallRAM()
        {
            Console.WriteLine("Installing Win RAM");
        }
        public override void InstallGPU()
        {
            Console.WriteLine("Installing Win GPU");
        }
        public override void InstallCooler()
        {
            Console.WriteLine("Installing Win Cooler");
        }
        public override void InstallMotherboard()
        {
            Console.WriteLine("Installing Win Motherboard");
        }
    }

    public class MacFactory : MainFactory
    {
        public override void PrepareBody()
        {
            Console.WriteLine("Mac Body Preparing");
        }
        public override void InstallCPU()
        {
            Console.WriteLine("Installing Mac CPU");
        }
        public override void InstallRAM()
        {
            Console.WriteLine("Installing Mac RAM");
        }
        public override void InstallGPU()
        {
            Console.WriteLine("Installing Mac GPU");
        }
        public override void InstallCooler()
        {
            Console.WriteLine("Installing Mac Cooler");
        }
        public override void InstallMotherboard()
        {
            Console.WriteLine("Installing Mac Motherboard");
        }
    }
}