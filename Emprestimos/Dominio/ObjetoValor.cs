using System.Collections.Generic;
using System.Linq;

namespace Loans.Domain
{
    /// <summary>
    /// Based on https://github.com/dotnet-architecture/eShopOnContainers/blob/master/src/Services/Ordering/Ordering.Domain/SeedWork/ObjetoValor.cs
    /// which is licensed under the MIT license: https://github.com/dotnet-architecture/eShopOnContainers/blob/master/LICENSE
    /// </summary>
    public abstract class ObjetoValor
    {
        protected static bool EqualOperator(ObjetoValor left, ObjetoValor right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ObjetoValor left, ObjetoValor right)
        {
            return !(EqualOperator(left, right));
        }

        protected abstract IEnumerable<object> ObterValoresAtomicos();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            ObjetoValor other = (ObjetoValor)obj;
            IEnumerator<object> thisValues = ObterValoresAtomicos().GetEnumerator();
            IEnumerator<object> otherValues = other.ObterValoresAtomicos().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }
                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        public override int GetHashCode()
        {
            return ObterValoresAtomicos()
             .Select(x => x != null ? x.GetHashCode() : 0)
             .Aggregate((x, y) => x ^ y);
        }

        public ObjetoValor GetCopy()
        {
            return MemberwiseClone() as ObjetoValor;
        }
    }
}