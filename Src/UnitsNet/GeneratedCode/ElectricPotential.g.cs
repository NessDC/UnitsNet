// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using UnitsNet.Units;
using System;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    /// In classical electromagnetism, the electric potential (a scalar quantity denoted by Φ, ΦE or V and also called the electric field potential or the electrostatic potential) at a point is the amount of electric potential energy that a unitary point charge would have when located at that point.
    /// </summary>
    public partial struct ElectricPotential : IComparable, IComparable<ElectricPotential>
    {
        /// <summary>
        /// Base unit of ElectricPotential.
        /// </summary>
        public readonly double Volts;

        public ElectricPotential(double volts) : this()
        {
            Volts = volts;
        }

        #region Properties

        #endregion

        #region Static 

        public static ElectricPotential Zero
        {
            get { return new ElectricPotential(); }
        }
        
        /// <summary>
        /// Get ElectricPotential from Volts.
        /// </summary>
        /// <remarks>Example: y = ax + b where x is value in Volts and y is value in base unit Volts.</remarks>
        public static ElectricPotential FromVolts(double volts)
        { 
            return new ElectricPotential(1 * volts);
        }

        /// <summary>
        /// Try to dynamically convert from ElectricPotential to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricPotential unit value.</returns> 
        public static ElectricPotential From(double value, ElectricPotentialUnit fromUnit)
        {
            switch (fromUnit)
            {
                case ElectricPotentialUnit.Volt:
                    return FromVolts(value);

                default:
                    throw new NotImplementedException("fromUnit: " + fromUnit);
            }
        }
        #endregion

        #region Arithmetic Operators

        public static ElectricPotential operator -(ElectricPotential right)
        {
            return new ElectricPotential(-right.Volts);
        }

        public static ElectricPotential operator +(ElectricPotential left, ElectricPotential right)
        {
            return new ElectricPotential(left.Volts + right.Volts);
        }

        public static ElectricPotential operator -(ElectricPotential left, ElectricPotential right)
        {
            return new ElectricPotential(left.Volts - right.Volts);
        }

        public static ElectricPotential operator *(double left, ElectricPotential right)
        {
            return new ElectricPotential(left*right.Volts);
        }

        public static ElectricPotential operator *(ElectricPotential left, double right)
        {
            return new ElectricPotential(left.Volts*right);
        }

        public static ElectricPotential operator /(ElectricPotential left, double right)
        {
            return new ElectricPotential(left.Volts/right);
        }

        public static double operator /(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts/right.Volts;
        }

        #endregion

        #region Equality / IComparable

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (!(obj is ElectricPotential)) throw new ArgumentException("Expected type ElectricPotential.", "obj");
            return CompareTo((ElectricPotential) obj);
        }

        public int CompareTo(ElectricPotential other)
        {
            return Volts.CompareTo(other.Volts);
        }

        public static bool operator <=(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts <= right.Volts;
        }

        public static bool operator >=(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts >= right.Volts;
        }

        public static bool operator <(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts < right.Volts;
        }

        public static bool operator >(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts > right.Volts;
        }

        public static bool operator ==(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts == right.Volts;
        }

        public static bool operator !=(ElectricPotential left, ElectricPotential right)
        {
            return left.Volts != right.Volts;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Volts.Equals(((ElectricPotential) obj).Volts);
        }

        public override int GetHashCode()
        {
            return Volts.GetHashCode();
        }

        #endregion
        
        #region Conversion
 
        /// <summary>
        /// Try to dynamically convert from ElectricPotential to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <param name="newValue">Value in new unit if successful, zero otherwise.</param>
        /// <returns>True if the two units were compatible and the conversion was successful.</returns> 
        public bool TryConvert(ElectricPotentialUnit toUnit, out double newValue)
        {
            switch (toUnit)
            {
                case ElectricPotentialUnit.Volt:
                    newValue = Volts;
                    return true;

                default:
                    newValue = 0;
                    return false;
            }
        }

        /// <summary>
        /// Dynamically convert from ElectricPotential to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="toUnit">Compatible unit to convert to.</param>
        /// <returns>Value in new unit if successful, exception otherwise.</returns> 
        /// <exception cref="NotImplementedException">If conversion was not successful.</exception>
        public double Convert(ElectricPotentialUnit toUnit)
        {
            double newValue;
            if (!TryConvert(toUnit, out newValue))
                throw new NotImplementedException("toUnit: " + toUnit);

            return newValue;
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0:0.##} {1}", Volts, UnitSystem.Create().GetDefaultAbbreviation(ElectricPotentialUnit.Volt));
        }
    }
} 