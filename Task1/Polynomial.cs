using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Immutable class which works with polynomials.
    /// </summary>
    public class Polynomial
    {
        
        #region fields
        /// <summary>
        /// Coeffitients of polynomial.
        /// </summary>
        private int[] arrCoeff;
        #endregion

        #region Constructors
        /// <summary>
        /// This constructor allaws to initialize Poynomial of 0 degree.
        /// </summary>
        /// <param name="coeff1">Coeffitient.</param>
        public Polynomial(int coeff1)
        {
            arrCoeff = new int[] { coeff1 };
        }

        /// <summary>
        /// This constructor allaws to initialize Poynomial of 1 degree.
        /// </summary>
        /// <param name="coeff1">Coeffitient of 1 degree.</param>
        /// <param name="coeff2">Coeffitient of 0 degree.</param>
        public Polynomial(int coeff1, int coeff2)
        {
            arrCoeff = new int[] { coeff1, coeff2 };
        }

        /// <summary>
        /// This constructor allaws to initialize Poynomial of 2 degree.
        /// </summary>
        /// <param name="coeff1">Coeffitient of 2 degree.</param>
        /// <param name="coeff2">Coeffitient of 1 degree.</param>
        /// <param name="coeff3">Coeffitient of 0 degree.</param>
        public Polynomial(int coeff1, int coeff2, int coeff3)
        {
            arrCoeff = new int[] { coeff1, coeff2, coeff3 };
        }

        /// <summary>
        /// This constructor allaws to initialize Poynomial of n degree.
        /// </summary>
        /// <param name="arr">Array of coeffitients of polynomial of n degree.</param>
        public Polynomial(params int[] arr)
        {
            arrCoeff = new int[arr.Length];
            Array.Copy(arr, arrCoeff, arr.Length);
        }
        #endregion

        #region Object override
        /// <summary>
        /// This method writes the Polynomial.
        /// </summary>
        /// <returns>Polynomial which is transformed into string.</returns>
        public override string ToString()
        {
            int kol = arrCoeff.Length;
            StringBuilder result = new StringBuilder("P(x) = ");

            for (int i = 0; i < arrCoeff.Length - 1; i++)
                result.Append($"{arrCoeff[i]}x^{--kol} + ");
            result.Append(arrCoeff.Last());

            return result.ToString();
        }

        /// <summary>
        /// This Method compares internal conditions in two polynomials.
        /// </summary>
        /// <param name="obj">Object type of polynomial.</param>
        /// <returns>True in case of equality of two polynomials.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Polynomial) || ((Polynomial)obj).GetHashCode() != GetHashCode())
                return false;

            for (int i = 0; i < arrCoeff.Length; i++)
                if (arrCoeff[i] != ((Polynomial)obj).arrCoeff[i])
                    return false;

            return true;
        }

        /// <summary>
        /// This method calculates hash of object type of Polynomial.
        /// </summary>
        /// <returns>Length of array of coeffitients.</returns>
        public override int GetHashCode()
        {
            return arrCoeff.Length;
        }
        #endregion

        #region overloading operations
        /// <summary>
        /// Overloding operation which allaws to find addition betwrrn two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial.</param>
        /// <param name="p2">Object type of polynomial.</param>
        /// <returns>New object type of polynomial.</returns>
        public static Polynomial operator + (Polynomial p1, Polynomial p2) => Add(p1,p2);

        /// <summary>
        /// Overloding operation which allaws to find substraction between two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial.</param>
        /// <param name="p2">Object type of polynomial.</param>
        /// <returns>New object type of polynomial.</returns>
        public static Polynomial operator - (Polynomial p1, Polynomial p2) => Sub(p1,p2);

        /// <summary>
        /// Overloding operation which allaws to find multiply between two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        public static Polynomial operator * (Polynomial p1, Polynomial p2) => Mul(p1,p2);

        /// <summary>
        /// Overloding operation which allaws to equal two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        public static bool operator == (Polynomial p1, Polynomial p2) => Eql(p1,p2);

        /// <summary>
        /// Overloding operation which allaws to equal two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        public static bool operator != (Polynomial p1, Polynomial p2) => NotEql(p1,p2);
        #endregion

        #region private operator overloading
        /// <summary>
        /// Overloding operation which allaws to find addition betwrrn two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial.</param>
        /// <param name="p2">Object type of polynomial.</param>
        /// <returns>New object type of polynomial.</returns>
        private static Polynomial Add(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentException();

            int maxSize = p1.arrCoeff.Length;
            if (p1.arrCoeff.Length < p2.arrCoeff.Length)
                maxSize = p2.arrCoeff.Length;
            
            Polynomial p = new Polynomial { arrCoeff = new int[maxSize] };
            Array.Copy(p1.arrCoeff, 0, p.arrCoeff, maxSize - p1.arrCoeff.Length, p1.arrCoeff.Length);
            for (int i = maxSize - p2.arrCoeff.Length; i < maxSize; i++)
                p.arrCoeff[i] += p2.arrCoeff[i];

            return p;
        }

        /// <summary>
        /// Overloding operation which allaws to find substraction between two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial.</param>
        /// <param name="p2">Object type of polynomial.</param>
        /// <returns>New object type of polynomial.</returns>
        private static Polynomial Sub(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentException();

            int maxSize = p1.arrCoeff.Length;
            if (p1.arrCoeff.Length < p2.arrCoeff.Length)
                maxSize = p2.arrCoeff.Length;

            Polynomial p = new Polynomial { arrCoeff = new int[maxSize] };
            Array.Copy(p1.arrCoeff, 0, p.arrCoeff, maxSize - p1.arrCoeff.Length, p1.arrCoeff.Length);
            for (int i = maxSize - p2.arrCoeff.Length; i < maxSize; i++)
                p.arrCoeff[i] -= p2.arrCoeff[i];

            return p;
        }

        /// <summary>
        /// Overloding operation which allaws to find multiply between two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        private static Polynomial Mul(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                throw new ArgumentException();

            Polynomial p = new Polynomial { arrCoeff = new int[p1.arrCoeff.Length + p2.arrCoeff.Length - 1] };
            for (int i = 0; i < p1.arrCoeff.Length; i++)
                for (int j = 0; j < p2.arrCoeff.Length; j++)
                    p.arrCoeff[i + j] += p1.arrCoeff[i] * p2.arrCoeff[j];

            return p;
        }

        /// <summary>
        /// Overloding operation which allaws to equal two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        private static bool Eql(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            else return false;
        }

        /// <summary>
        /// Overloding operation which allaws to equal two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        private static bool NotEql(Polynomial p1, Polynomial p2)
        {
            if (!ReferenceEquals(p1, p2)) return true;
            else return false;
        }
        #endregion
    }
}