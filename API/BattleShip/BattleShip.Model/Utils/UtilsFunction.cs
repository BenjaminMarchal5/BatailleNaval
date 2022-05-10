using BattleShip.Model.Enum;
using BattleShip.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model.Utils
{
    public class UtilsFunction : IUtils
    {
        private static UtilsFunction instance;
        public Random random;


        private UtilsFunction()
        {
            random = new Random();
        }

        public static UtilsFunction GetInstance()
        {
            if (instance == null)
            {
                instance = new UtilsFunction(); 
            }
            return instance;
        }
        
        public  EDirection GetDirection(Position p1,Position p2)
        {
            if (p1.X == p2.X)
            {
                return EDirection.HORIZONTAL;
            }
            else if (p1.Y == p2.Y)
            {
                return EDirection.VERTICAL;
            }
            else if (Math.Abs(p1.X - p2.X) == Math.Abs(p1.Y - p2.Y))
            {
                return EDirection.DIAGONAL;
            }
            else
            {
                throw new Exception("Erreur de direction");
            }
        }

        public  Position GetMin(Position p1, Position p2, string attribute)
        {
            if (attribute == "X")
            {
                if (p1.X<p2.X)
                {
                    return p1;
                }
                else
                {
                    return p2;
                }
            }
            else
            {
                if (p1.Y < p2.Y)
                {
                    return p1;
                }
                else
                {
                    return p2;
                }
            }
        }

        public  Position GetMax(Position p1, Position p2, string attribute)
        {
            if (attribute == "X")
            {
                if (p1.X > p2.X)
                {
                    return p1;
                }
                else
                {
                    return p2;
                }
            }
            else
            {
                if (p1.Y > p2.Y)
                {
                    return p1;
                }
                else
                {
                    return p2;
                }
            }
        }

        public  Position GetMin(List<Position> positions)
        {
            Position p = null;
            if (positions.Count > 0)
            {
                p = positions[0];
                for (int i = 1; i < positions.Count; i++)
                {
                    if (positions[i].X < p.X)
                    {
                        p = positions[i];
                    }
                }
            }
            return p;
        }

        public  Position GetMax(List<Position> positions)
        {
            Position p = null;
            if (positions.Count > 0)
            {
                p = positions[0];
                for (int i = 1; i < positions.Count; i++)
                {
                    if (positions[i].X > p.X)
                    {
                        p = positions[i];
                    }
                }
            }
            return p;
        }
        public  Position PositionNextTo(Position Start,Position End ,int GridSize)
        {
            EDirection Direction = GetDirection(Start, End);
            Position res = new Position();
            int res2 = random.Next(0, 2);
            int res4 = random.Next(0, 4);
            if (Direction==EDirection.HORIZONTAL)
            {
                List<Position> selectRandom = new List<Position>();
                var min = GetMin(Start, End,"X");
                var max = GetMax(Start, End,"X");
                if (min.X-1>=0)
                {
                    var clone = UtilsClone<Position>.Clone(min);
                    clone.X -= 1;
                    selectRandom.Add(clone);
                }
                if (max.X+1<=GridSize-1)
                {
                    var clone = UtilsClone<Position>.Clone(max);
                    clone.X += 1;
                    selectRandom.Add(clone);
                }
                res = selectRandom[random.Next(0, selectRandom.Count)];
            }
            else if (Direction == EDirection.VERTICAL)
            {
                List<Position> selectRandom = new List<Position>();
                var min = GetMin(Start, End, "Y");
                var max = GetMax(Start, End, "Y");
                if (min.Y - 1 >= 0)
                {
                    var clone = UtilsClone<Position>.Clone(min);
                    clone.Y -= 1;
                    selectRandom.Add(clone);
                }
                if (max.Y + 1 <= GridSize - 1)
                {
                    var clone = UtilsClone<Position>.Clone(max);
                    clone.Y += 1;
                    selectRandom.Add(clone);
                }
                res = selectRandom[random.Next(0, selectRandom.Count)];
            }
            else if (Direction == EDirection.DIAGONAL)
            {
                bool BothBigger = Start.X <= End.X && Start.Y <= End.Y;
                var min = GetMin(Start, End, "X");
                var max = GetMax(Start, End, "X");
                List<Position> selectRandom = new List<Position>();
                if (BothBigger)
                {
                    if (min.X-1>=0 && min.Y+1<=GridSize-1)
                    {
                        var clone = UtilsClone<Position>.Clone(min);
                        clone.Y += 1;
                        clone.X -= 1;
                        selectRandom.Add(clone);
                    }
                    if (max.Y - 1 >= 0 && max.X + 1 <= GridSize - 1)
                    {
                        var clone = UtilsClone<Position>.Clone(max);
                        clone.X += 1;
                        clone.Y -= 1;
                        selectRandom.Add(clone);
                    }
                }
                else
                {
                    if (min.Y - 1 >= 0 && min.X - 1 >=0)
                    {
                        var clone = UtilsClone<Position>.Clone(min);
                        clone.Y -= 1;
                        clone.X -= 1;
                        selectRandom.Add(clone);
                    }
                    if (max.Y + 1 <= GridSize - 1 && max.X + 1 <= GridSize - 1)
                    {
                        var clone = UtilsClone<Position>.Clone(max);
                        clone.X += 1;
                        clone.Y += 1;
                        selectRandom.Add(clone);
                    }
                }
                res = selectRandom[random.Next(0, selectRandom.Count)];

            }
            return res;
        }

        public  string Hash(string value)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(value);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
