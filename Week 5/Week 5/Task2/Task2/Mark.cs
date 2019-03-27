using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Task2
{
    [Serializable]
    public class Mark : ISerializable
    {
        public int points;
        public string letter;

        public Mark()
        {
            
        }

        public string GetLetter(int a)
        {
            if (points < 100 && points >= 95)
                return "A";
            else if (points < 95 && points >= 90)
                return "A-";
            else if (points < 90 && points >= 85)
                return "B+";
            else if (points < 85 && points >= 80)
                return "B";
            else if (points < 80 && points >= 75)
                return "B-";
            else if (points < 75 && points >= 70)
                return "C+";
            else if (points < 70 && points >= 65)
                return "C";
            else if (points < 65 && points >= 60)
                return "C-";
            else if (points < 60 && points >= 55)
                return "D+";
            else if (points < 55 && points >= 50)
                return "D";
            else if (points < 50)
                return "F";
            else
                return "not valid point";
            
        }

        public Mark(int points)
        {
            this.points = points;
            letter = GetLetter(points);
        
        }

        

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Points", points);
        }

        public Mark(SerializationInfo info, StreamingContext context)
        {
            points = (int)info.GetValue("Points", typeof(int));
        }

        public string ToString()
        {
            return String.Format("{0} point is equivalent to {1} letter mark", points, letter);
        }
        
    }
}
