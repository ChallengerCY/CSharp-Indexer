using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            //c#中的indexer可以使一个类(任意的，合理的类)像数组一样访问类里面的单元
            //c#索引器的语法
            var indexerNames = new IndexerNames();
            indexerNames[0] = "Challener";
            indexerNames[1] = "CY";
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(indexerNames[i]);
            }

            Console.WriteLine(indexerNames["Chall"]);
            Console.WriteLine(indexerNames["CY"]);
            Console.ReadLine();


            /*
             * 代码的强壮性:
             * 1、要考虑参数的取值范围
             * 2、考虑错误处理机制
             * 3、给索引器添加访问修饰符，尽量用最小的访问修饰符，增加代码的安全性
             */
        }
    }

    class IndexerNames
    {
        private string[] names = new string[10];
        //写构造函数
        public IndexerNames()
        {
            for (int i = 0; i < 9; i++)
            {
                names[i] = "N/A";
            }
        }
        //索引器写法，很像属性

        //一个Class可以重载多个索引器，通过传递的参数来识别
        //建立一个整形的索引器
        public string this[int index]
        {
            get
            {
                string temp;
                if (index >= 0 && index <= names.Length - 1)
                {
                    temp = names[index];
                }
                else
                {
                    temp = " ";
                }
                return temp;
            }

            set
            {
                if (index >= 0 && index <= names.Length - 1)
                {
                    names[index] = value;
                }
            }
        }
        //建立一个string类型的索引器
        public int this[string name]
        {
            get
            {
                int index = 0;
                while (index < names.Length)
                {
                    if (names[index] == name)
                    {
                        return index;
                    }
                    index++;
                }
                return -1;
            }
        }
    }

    //C#中的接口也可以建立索引
    public interface IIdndexer
    {
        int this[int index]
        {
            get;
            set;
        }
    }

    public class Inderxer : IIdndexer
    {
        private int[] indexList = new int[100];
        public int this[int index]
        {
            get
            {
                return indexList[index];
            }
            set
            {
                indexList[index] = value;
            }
        }
    }
}
