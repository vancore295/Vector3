using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Bomani Kernizan

namespace Vector3D
{
    class Vector3
    {
      private float x, y, z, w;
      float toDegrees = (float)(180 / Math.PI);
      float toRadians = (float)(Math.PI / 180);

      public float X
      {
          get { return x; }
          set { x = value; }
     }
      public float Y
      {
          get { return y; }
          set { y = value; }
      }
      public float Z
      {
          get { return z; }
          set { z = value; }
      }
      public float W
      {
          get { return w; }
          set { w = value; }
      }

      //empty constuctor
      public Vector3()
      {
          X = 0;
          Y = 0;
          Z = 0;
          W = 0;
      }
        //class constructor
      public Vector3(float xCord, float yCord, float zCord)
      {
          X = xCord;
          Y = yCord;
          Z = zCord;
      }//End constructor

        //set cordinates for 3D vectors
      public void SetRectGivenRect(float x3D, float y3D, float z3D)
      {
          X = x3D;
          Y = y3D;
          Z = z3D;
      }//End SetGivenRect

        //set cordinates for 2D vectors
      public void SetRectGivenRect(float x2D, float y2D)
      {
          X = x2D;
          Y = y2D;
          Z = 0;
      }//End Set Given Rect

        //set the rectangular coordinates given the magnitude and heading for 2D
      public void SetRectGivenPolar(float magnitude, float heading)
      {
          heading *= toDegrees;
          X = (float)(magnitude * Math.Cos(heading));
          Y = (float)(magnitude * Math.Sin(heading));
      }//End SetRectGivenPolar

        //set the rectangular coordinates for the vector given an input of the magnitude, heading and pitch for 3D
      public void SetRectGivenMagHeadPitch(float magnitue, float heading, float pitch)
      {
          heading *= toDegrees;
          pitch *= toDegrees;
          X = (float)(magnitue * (float)Math.Cos(pitch) * (float)Math.Cos(heading));
          Y = (float)(magnitue * (float)Math.Cos(pitch) * (float)Math.Sin(heading));
          Z = (float)(magnitue * (float)Math.Sin(pitch));
      }//End SetRectGivenMagHeadPitch

        //shows the x
      public float GetX()
      {
          return X;
      }//End GetX

        //shows the y
      public float GetY()
      {
          return Y;
      }//End GetY

        //shows the z
        public float GetZ()
        {
            return Z;
        }//End GetZ

        //gets the Alpha angle
        public float GetAlpha()
        {
            float alpha, magnitude;
            magnitude = GetMagnitude();

            if (magnitude != 0)
            {
                alpha = (float)(Math.Acos(X / magnitude));
            }
            else
            {
                alpha = 0f;
            }
            return alpha;
        }//End GetAlpha

        //gets the Beta angle
        public float GetBeta()
        {
            float beta, magnitude;
            magnitude = GetMagnitude();

            if (magnitude != 0)
            {
                beta = (float)(Math.Acos(Y / magnitude));
            }
            else
            {
                beta = 0f;
            }
            return beta;
        }//End GetBeta

        //gets the Gamma angle
        public float GetGamma()
        {
            float gamma, magnitude;
            magnitude = GetMagnitude();

            if (magnitude != 0)
            {
                gamma = (float)(Math.Acos(Z / magnitude));
            }
            else
            {
                gamma = 0f;
            }
            return gamma;
        }//End Get Gamma

        //gets the Magnitude
        public float GetMagnitude()
        {
            float magnitude;

            magnitude = (float)(Math.Sqrt(X * X + Y * Y + Z * Z));

            return magnitude;
        }//End GetMagnitude

        //gets the Pitch
        public float GetPitch()
        {
            float pitch, magnitude;
            magnitude = GetMagnitude();

            if (magnitude != 0)
            {
                pitch = (float)(Math.Asin(Z / magnitude));
            }

            else
            {
                pitch = 0f;
            }

            return pitch;
        }//End GetPitch

        //gets the Heading
        public float GetHeading()
        {
            float heading, magnitude;
            magnitude = GetMagnitude();

            if ((X * X + Y * Y) != 0)
            {
                heading = (float)(Math.Acos(X / (Math.Sqrt(X * X + Y * Y))));
            }
            else
            {
                heading = 0f;
            }
            if (Y < 0)
            {
                heading = (float)((2 * Math.PI) - heading);
            }


            return heading;
        }//End GetHeading

        //prints the cordinates to the screen
        public void PrintRect()
        {
            Console.WriteLine("X: {0},Y: {1},Z: {2}", X, Y, Z);
        }//End PrintRect

        //prints Magnitude heading and Pitch
        public void PrintMagHeadPitch()
        {
            float magnitude, heading, pitch;
            magnitude = GetMagnitude();
            heading = GetHeading();
            pitch = GetPitch();

            Console.WriteLine("Magnitude: {0}, Heading: {1}, Pitch {2}", magnitude, heading, pitch);
        }//End printMagHeadPitch

        //prints the angles to the screen
        public void PrintAngles()
        {
            float alpha, beta, gamma;
            alpha = GetAlpha();
            beta = GetBeta();
            gamma = GetGamma();

            Console.WriteLine("Alpha: {0}, Beta: {1}, Gamma: {2}", alpha, beta, gamma);
        }//End PrintAngles

        //find the sum of two vectors
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.GetX() + v2.GetX(), v1.GetY() + v2.GetY(), v1.GetZ() + v2.GetZ());
        }//end SumOfTwoVectors

        //find the difference of two vectors
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.GetX() - v2.GetX(), v1.GetY() - v2.GetY(), v1.GetZ() - v2.GetZ());
        }//end DifferenceOfTwoVectors

        //scalar multiplication of a vector
        public Vector3 ScalarMultiplication(float scalar)
        {
            return new Vector3(scalar * X, scalar * Y, scalar * Z);
        }//end ScalarMultiplication

        //normalization of a vector
        public Vector3 NormalizeVector(Vector3 v)
        {
            float newX, newY, newZ;
            newX = (float)(1 / v.GetX());
            newY = (float)(1 / v.GetY());
            newZ = (float)(1 / v.GetZ());
            return new Vector3(newX * v.GetX(), newY * v.GetY(), newZ * v.GetZ());
        }//end NormalizeVector

        //find the dot product of a vector
        public static float operator *(Vector3 v1, Vector3 v2)
        {
            float dotProduct;
            dotProduct = (float)(v1.GetX() * v2.GetX() + v1.GetY() * v2.GetY() + v1.GetZ() * v2.GetZ());
            return dotProduct;
        }//end DotProduct

        //find the angle between two vectors
        public static float operator ^(Vector3 v1, Vector3 v2)
        {
            float dotProduct = (float)(v1 * v2);
            float angle = (float)(dotProduct / (v1.GetMagnitude() * v2.GetMagnitude()));

            return angle;
        }//end AngleBetweenVectors

        //find  the perpendicular projection of one vector onto another 
        public static Vector3 operator %(Vector3 v1, Vector3 v2)
        {
            Vector3 parallelVec = new Vector3();
            parallelVec = v1 | v2;

            return new Vector3(v1.GetX() - parallelVec.GetX(), v1.GetY() - parallelVec.GetY(), v1.GetZ() - parallelVec.GetZ());
        }//end PerpendiculatProjection

        //find the parallel projection of one vector onto another
        public static Vector3 operator |(Vector3 v1, Vector3 v2)
        {
            float magSquared = (float)(v2.GetMagnitude() * v2.GetMagnitude());

            if (magSquared == 0f)
            {
                return new Vector3();
            }

            float scalar = ((v1.GetX() * v2.GetX() + v1.GetY() * v2.GetY() + v1.GetZ() * v2.GetZ()) / magSquared);

            return new Vector3(v2.GetX() * scalar, v2.GetY() * scalar, v2.GetZ() * scalar);
        }//end ParallelProjection
    }
}