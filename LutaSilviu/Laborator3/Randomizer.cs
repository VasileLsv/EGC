using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator3
{
    /// <summary>
    /// Clasa Randomizer se foloseste de clasa Random din .Net
    /// pentru a genera valori int si Color random
    /// </summary>
    public class Randomizer
    {
        Random ran;
        
        public Randomizer()
        {
            ran = new Random();
        }
        /// <summary>
        /// genereaza un numar aflat intre 0 si valoarea maxValue
        /// </summary>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public int getRandomPositiveInt(int maxValue)
        {
            return ran.Next(0,maxValue);
        
        }

        /// <summary>
        /// genereaza o culoare random
        /// </summary>
        /// <returns></returns>
        public Color generateRandomColor()
        {
            int genR=ran.Next(0,255);
            int genG=ran.Next(0,255);
            int genB=ran.Next(0,255);
            int genA =ran.Next(0,255);

            return Color.FromArgb(genA,genR,genG,genB);
        }

    }
}
