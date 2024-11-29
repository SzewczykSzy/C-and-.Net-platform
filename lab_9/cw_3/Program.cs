using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace cw_3
{
    internal class Program
    {
        public class DisposeObject : IDisposable 
        {
            protected bool disposed = false;
            private IntPtr handle;                          // Pamięć niezarządzana
            private Component components = new Component(); // Obiekt zarządzany

            public DisposeObject(int size)
            {
                // Alokacja pamięci niezarządzanej
                handle = Marshal.AllocHGlobal(size + 1);
                Console.WriteLine("Zaalokowano pamięć niezarządzaną o rozmiarze: " + (size + 1));
            }

            ~DisposeObject() { Dispose(false); }

            public void Dispose() 
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing) 
            {
                if (!disposed) 
                {
                    if (disposing) 
                    {
                        components.Dispose();
                    }
                    if (handle != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(handle);
                        handle = IntPtr.Zero;
                        Console.WriteLine("Zwolniono pamięć niezarządzaną");
                    }
                }
                disposed = true;
            }
        }
        static void Main(string[] args)
        {
            using (DisposeObject obj = new DisposeObject(100))
            {
                Console.WriteLine("Obiekt w użyciu");
            } // Pamięć i zasoby zostaną zwolnione deterministycznie

            Console.WriteLine("Obiekt poza zakresem");


            Console.ReadLine();
        }
    }
}
