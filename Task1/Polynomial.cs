using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Polynomial
    {
        #region fields
        private int[] arrCoeff;
        private double x;
        #endregion

        #region Constructors
        public Polynomial(int coeff1)
        {
            arrCoeff = new int[] { coeff1 };
        }

        public Polynomial(int coeff1, int coeff2)
        {
            arrCoeff = new int[] { coeff1, coeff2 };
        }

        public Polynomial(int coeff1, int coeff2, int coeff3)
        {
            arrCoeff = new int[] { coeff1, coeff2, coeff3 };
        }

        public Polynomial(params int[] arr)
        {
            arrCoeff = new int[arr.Length];
            Array.Copy(arr, arrCoeff, arr.Length);
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            int kol = arrCoeff.Length;
            StringBuilder result = new StringBuilder("P(x) = ");

            for (int i = 0; i < arrCoeff.Length - 1; i++)
                result.Append($"{arrCoeff[i]}x^{--kol} + ");
            result.Append(arrCoeff.Last());

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Polynomial) || ((Polynomial)obj).GetHashCode() != GetHashCode())
                return false;

            for (int i = 0; i < arrCoeff.Length; i++)
                if (arrCoeff[i] != ((Polynomial)obj).arrCoeff[i])
                    return false;

            return true;
        }

        public override int GetHashCode()
        {
            return arrCoeff.Length;
        }
        #endregion

        #region operator overloading
        public static Polynomial operator + (Polynomial p1, Polynomial p2) => Add(p1,p2);
        public static Polynomial operator - (Polynomial p1, Polynomial p2) => Sub(p1,p2);
        public static Polynomial operator * (Polynomial p1, Polynomial p2) => Mul(p1,p2);
        public static bool operator == (Polynomial p1, Polynomial p2) => Eql(p1,p2);
        public static bool operator != (Polynomial p1, Polynomial p2) => NotEql(p1,p2);
        #endregion

        #region private operator overloading
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

        private static bool Eql(Polynomial p1, Polynomial p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            else return false;
        }

        private static bool NotEql(Polynomial p1, Polynomial p2)
        {
            if (!ReferenceEquals(p1, p2)) return true;
            else return false;
        }
        #endregion
    }
}