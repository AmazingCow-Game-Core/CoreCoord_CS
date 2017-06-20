using System;
using System.Collections.Generic;

namespace AmazingCow.GameCores.CoreCoord
{
    public struct Coord
    {
        #region Public Vars
        public int X;
        public int Y;
        #endregion //Public Vars


        #region Static Properties
        public static Coord Left  { get { return new Coord( 0, -1); } }
        public static Coord Right { get { return new Coord( 0, +1); } }
        public static Coord Up    { get { return new Coord(-1,  0); } }
        public static Coord Down  { get { return new Coord(+1,  0); } }
        #endregion //Static Properties


        #region Operators
        public static bool operator ==(Coord lhs, Coord rhs)
        {
            return (lhs.X == rhs.X) && (lhs.Y == rhs.Y);
        }

        public static bool operator !=(Coord lhs, Coord rhs)
        {
            return !(lhs == rhs);
        }

        public static Coord operator +(Coord lhs, Coord rhs)
        {
            return new Coord(
                lhs.Y + rhs.Y,
                lhs.X + rhs.X
            );
        }

        public static Coord operator -(Coord lhs, Coord rhs)
        {
            return new Coord(
                lhs.Y - rhs.Y,
                lhs.X - rhs.X
            );
        }

        public static Coord operator *(Coord lhs, int scalar)
        {
            return new Coord(
                lhs.Y * scalar,
                lhs.X * scalar
            );
        }
        #endregion //Operators


        #region CTOR 
        public Coord(int y = 0, int x = 0)
        {
            Y = y;
            X = x;
        }
        #endregion //CTOR


        #region Public Methods 
        public Coord GetUp(int offset = 1)
        {
            return (this + (Coord.Up * offset));
        }

        public Coord GetDown(int offset = 1)
        {
            return (this + (Coord.Down * offset));
        }

        public Coord GetLeft(int offset = 1)
        {
            return (this + (Coord.Left * offset));
        }

        public Coord GetRight(int offset = 1)
        {
            return (this + (Coord.Right * offset));
        }

        public Coord GetMiddle(Coord that)
        {
            return new Coord(
                (this.Y + that.Y) / 2,
                (this.X + that.X) / 2
            );
        }

        public List<Coord> GetOrthogonal()
        {
            return new List<Coord>(4) {
                this + Coord.Up, 
                this + Coord.Right, 
                this + Coord.Down, 
                this + Coord.Left
            };
        }

        public List<Coord> GetSurrounding()
        {
            return new List<Coord>(4) {
                this + Coord.Up,                 //Top
                this + Coord.Up + Coord.Right,   //Top Right

                this + Coord.Right,              //Right.

                this + Coord.Down + Coord.Right, //Bottom Right.
                this + Coord.Down,               //Bottom
                this + Coord.Down + Coord.Left,  //Bottom Left.

                this + Coord.Left,               //Left.

                this + Coord.Up + Coord.Left,    //Top Left
            };
        }

        public bool IsSameX(Coord that)
        {
            return this.X == that.X;
        }

        public bool IsSameY(Coord that)
        {
            return this.Y == that.Y;
        }

        public void MakeUnit()
        {
            if(this.X != 0)
                this.X /= Math.Abs(this.X);

            if(this.Y != 0)
                this.Y /= Math.Abs(this.Y);
        }

        public Coord GetUnit()
        {
            var other = this;
            other.MakeUnit();

            return other;
        }
        #endregion //Public Methods
    
    }// class Coord
}//namespace AmazingCow.GameCore.CoreCoord

