using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myDLL
{
    /// <summary>
    /// interface of operate
    /// </summary>
    public interface IOperate
    {
        /// <summary>
        /// sum of (a,b)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        int getSum(int a, int b);
    }
    /// <summary>
    /// operate1
    /// </summary>
    public class Operate1:IOperate
    {
        /// <summary>
        /// sum of (a,b)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int getSum(int a, int b)
        {
            return a + b;
        }
    }    

}
