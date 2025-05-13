namespace Comercio.Domain
{
    public class Base
    {
        protected long _id;
        public long Id
        {
            get {return _id;}
            set {_id = value;}
        }
    }
}