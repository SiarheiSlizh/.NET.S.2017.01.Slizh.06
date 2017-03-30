using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Immutable class which works with polynomials.
    /// </summary>
    public sealed class Polynomial: ICloneable
    {
        #region fields
        /// <summary>
        /// Coeffitients of polynomial.
        /// </summary>
        private readonly double[] arrCoeff;

        /// <summary>
        /// Precision.
        /// </summary>
        public static double epsilon;
        #endregion

        #region Indexers
        public double this [int i]
        {
            get
            {
                if (i > arrCoeff.Length - 1 || i < 0)
                    throw new ArgumentOutOfRangeException();
                return arrCoeff[i];
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// This constructor allaws to initialize static field epsilon
        /// </summary>
        static Polynomial()
        {
            epsilon = double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"], CultureInfo.InvariantCulture);
        }

    /// <summary>
    /// This constructor allaws to initialize Poynomial of n degree.
    /// </summary>
    /// <param name="arr">Array of coeffitients of polynomial of n degree.</param>
    public Polynomial(params double[] arr)
        {
            arrCoeff = new double[arr.Length];

            for (int i = 0; i < arr.Length; i++)
                if (arr[i] < epsilon && arr[i] > -epsilon)
                    arrCoeff[i] = 0;
                else
                    arrCoeff[i] = arr[i];
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
                if (this[i] != 0)
                    result.Append($"{this[i]}x^{--kol} + ");
                else kol--;
            result.Append(arrCoeff.Last());

            return result.ToString();
        }

        /// <summary>
        /// This Method compares two polynomials.
        /// </summary>
        /// <param name="obj">Object type of polynomial.</param>
        /// <returns>True in case of equality of two polynomials.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;

            if (obj.GetType() != this.GetType()) return false;
            return Equals((Polynomial)obj);
        }

        /// <summary>
        /// This Method compares two polynomials.
        /// </summary>
        /// <param name="other">Type of polynomial.</param>
        /// <returns>True in case of equality of two polynomials.</returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (this.GetHashCode() != other.GetHashCode())
                return false;

            for (int i = 0; i < other.arrCoeff.Length; i++)
                if (!this[i].Equals(other[i]))
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
        public static Polynomial operator + (Polynomial leftPl, Polynomial rightPl) => Add(leftPl, rightPl);

        /// <summary>
        /// Overloding operation which allaws to find substraction between two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial.</param>
        /// <param name="p2">Object type of polynomial.</param>
        /// <returns>New object type of polynomial.</returns>
        public static Polynomial operator - (Polynomial leftPl, Polynomial rightPl) => Sub(leftPl, rightPl);

        /// <summary>
        /// Overloding operation which allaws to find multiply between two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        public static Polynomial operator * (Polynomial leftPl, Polynomial rightPl) => Mul(leftPl, rightPl);

        /// <summary>
        /// Overloding operation which allaws to equal two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        public static bool operator == (Polynomial leftPl, Polynomial rightPl) => Eql(leftPl, rightPl);

        /// <summary>
        /// Overloding operation which allaws to equal two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        public static bool operator != (Polynomial leftPl, Polynomial rightPl) => NotEql(leftPl, rightPl);
        

        /// <summary>
        /// Overloding operation which allaws to find addition betwrrn two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial.</param>
        /// <param name="p2">Object type of polynomial.</param>
        /// <returns>New object type of polynomial.</returns>
        public static Polynomial Add(Polynomial leftPl, Polynomial rightPl)
        {
            if (ReferenceEquals(leftPl,null) || ReferenceEquals(rightPl,null))
                throw new ArgumentNullException();

            int maxSize = Math.Max(leftPl.arrCoeff.Length, rightPl.arrCoeff.Length);

            double[] arr = new double[maxSize];
            Array.Copy(leftPl.arrCoeff, 0, arr, maxSize - leftPl.arrCoeff.Length, leftPl.arrCoeff.Length);
            for (int i = maxSize - rightPl.arrCoeff.Length; i < maxSize; i++)
                arr[i] += rightPl.arrCoeff[i];

            return new Polynomial(arr);
        }

        /// <summary>
        /// Overloding operation which allaws to find substraction between two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial.</param>
        /// <param name="p2">Object type of polynomial.</param>
        /// <returns>New object type of polynomial.</returns>
        public static Polynomial Sub(Polynomial leftPl, Polynomial rightPl)
        {
            if (ReferenceEquals(leftPl, null) || ReferenceEquals(rightPl, null))
                throw new ArgumentNullException();

            return leftPl + GetReserveSign(rightPl);
        }

        /// <summary>
        /// Method creates new polynomial based on existing with elements of reserve sign.
        /// </summary>
        /// <param name="p">Polynomial.</param>
        /// <returns>New polynomial.</returns>
        public static Polynomial GetReserveSign (Polynomial p)
        {
            if (ReferenceEquals(p, null))
                throw new ArgumentNullException();

            double[] tempCoeff = new double[p.arrCoeff.Length];

            for (int i = 0; i < tempCoeff.Length; i++)
                tempCoeff[i] = p[i] * (-1);

            return new Polynomial(tempCoeff);
        }

        /// <summary>
        /// Overloding operation which allaws to find multiply between two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        public static Polynomial Mul(Polynomial leftPl, Polynomial rightPl)
        {
            if (ReferenceEquals(leftPl, null) || ReferenceEquals(rightPl, null))
                throw new ArgumentNullException();

            double[] tempCoeff = new double[leftPl.arrCoeff.Length + rightPl.arrCoeff.Length - 1];

            for (int i = 0; i < leftPl.arrCoeff.Length; i++)
                for (int j = 0; j < rightPl.arrCoeff.Length; j++)
                    tempCoeff[i + j] += leftPl.arrCoeff[i] * rightPl.arrCoeff[j];

            return new Polynomial(tempCoeff);
        }

        /// <summary>
        /// Overloding operation which allaws to equal two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        public static bool Eql(Polynomial leftPl, Polynomial rightPl)
        {
            if (ReferenceEquals(leftPl, rightPl)) return true;

            if (ReferenceEquals(leftPl, null) || ReferenceEquals(rightPl, null))
                throw new ArgumentNullException();

            else return leftPl.Equals(rightPl);
        }

        /// <summary>
        /// Overloding operation which allaws to equal two objects type of polynomial.
        /// </summary>
        /// <param name="p1">Object type of polynomial</param>
        /// <param name="p2">Object type of polynomial</param>
        /// <returns>New object type of polynomial.</returns>
        public static bool NotEql(Polynomial leftPl, Polynomial rightPl) => !Eql(leftPl, rightPl);
        #endregion

        #region Clone
        /// <summary>
        /// Method creates new polynomial based on existing.
        /// </summary>
        /// <returns>New polynomial.</returns>
        public Polynomial Clone() => new Polynomial(this.arrCoeff);       

        /// <summary>
        /// Method creates new polynomial based on existing.
        /// </summary>
        /// <returns>New polynomial.</returns>
        object ICloneable.Clone() => this.Clone();
        #endregion
    }
}