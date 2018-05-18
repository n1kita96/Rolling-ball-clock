using System;
/// ===============================
///  AUTHOR 
///  Mykyta Shvets
/// ===============================
namespace Time_and_motion
{
    class Ball
    {
        public int Number { get; set; }

        //Two balls are equal if their numbers are equal
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Ball b = (Ball)obj;
            return (Number == b.Number);
        }
        //you can not override equals without overriding hash code
        public override int GetHashCode() => Number * 31;
    }
}
