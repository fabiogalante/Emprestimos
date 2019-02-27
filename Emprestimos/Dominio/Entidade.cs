using System;

namespace Emprestimos.Dominio
{
    /// <summary>
    /// Based on: https://github.com/dotnet-architecture/eShopOnContainers/blob/master/src/Services/Ordering/Ordering.Domain/SeedWork/Entidade.cs
    /// which is licensed under the MIT license: https://github.com/dotnet-architecture/eShopOnContainers/blob/master/LICENSE
    /// </summary>
    public abstract class Entidade
    {
        int? _requestedHashCode;
        int _Id;
        public virtual int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entidade))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entidade item = (Entidade)obj;

            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

            return _requestedHashCode.Value;
        }

        public static bool operator ==(Entidade left, Entidade right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entidade left, Entidade right)
        {
            return !(left == right);
        }
    }
}
