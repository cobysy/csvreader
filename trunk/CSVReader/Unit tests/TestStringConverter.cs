/* CSVReader - a simple open source C# class library to read CSV data
 * by Andrew Stellman - http://www.stellman-greene.com/CSVReader
 * 
 * Unit tests/TestStringConverter.cs - NUnit tests to verify the StringConverter class
 * 
 * download the latest version: http://svn.stellman-greene.com/CSVReader
 * 
 * (c) 2008, Stellman & Greene Consulting
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of Stellman & Greene Consulting nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY STELLMAN & GREENE CONSULTING ''AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL STELLMAN & GREENE CONSULTING BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 */

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Com.StellmanGreene.CSVReader.Unit_tests
{
    [TestFixture]
    public class TestStringConverter
    {
        [Test]
        public void TestFindStringType()
        {
            object convertedValue;

            Assert.AreEqual(typeof(byte), StringConverter.ConvertString("153", out convertedValue));
            Assert.IsTrue(convertedValue is byte);
            Assert.AreEqual(153, convertedValue);

            Assert.AreEqual(typeof(byte), StringConverter.ConvertString("0", out convertedValue));
            Assert.IsTrue(convertedValue is byte);
            Assert.AreEqual(0, convertedValue);

            Assert.AreEqual(typeof(byte), StringConverter.ConvertString("255", out convertedValue));
            Assert.IsTrue(convertedValue is byte);
            Assert.AreEqual(255, convertedValue);


            Assert.AreEqual(typeof(short), StringConverter.ConvertString("256", out convertedValue));
            Assert.IsTrue(convertedValue is short);
            Assert.AreEqual(256, convertedValue);

            Assert.AreEqual(typeof(short), StringConverter.ConvertString("1573", out convertedValue));
            Assert.IsTrue(convertedValue is short);
            Assert.AreEqual(1573, convertedValue);

            Assert.AreEqual(typeof(short), StringConverter.ConvertString("-36", out convertedValue));
            Assert.IsTrue(convertedValue is short);
            Assert.AreEqual(-36, convertedValue);

            Assert.AreEqual(typeof(short), StringConverter.ConvertString("-32768", out convertedValue));
            Assert.IsTrue(convertedValue is short);
            Assert.AreEqual(-32768, convertedValue);

            Assert.AreEqual(typeof(short), StringConverter.ConvertString("32767", out convertedValue));
            Assert.IsTrue(convertedValue is short);
            Assert.AreEqual(32767, convertedValue);


            Assert.AreEqual(typeof(int), StringConverter.ConvertString("-32769", out convertedValue));
            Assert.IsTrue(convertedValue is int);
            Assert.AreEqual(-32769, convertedValue);

            Assert.AreEqual(typeof(int), StringConverter.ConvertString("5132763", out convertedValue));
            Assert.IsTrue(convertedValue is int);
            Assert.AreEqual(5132763, convertedValue);

            Assert.AreEqual(typeof(int), StringConverter.ConvertString("2147483647", out convertedValue));
            Assert.IsTrue(convertedValue is int);
            Assert.AreEqual(2147483647, convertedValue);

            Assert.AreEqual(typeof(int), StringConverter.ConvertString("-2147483648", out convertedValue));
            Assert.IsTrue(convertedValue is int);
            Assert.AreEqual(-2147483648, convertedValue);


            Assert.AreEqual(typeof(long), StringConverter.ConvertString("2147483648", out convertedValue));
            Assert.IsTrue(convertedValue is long);
            Assert.AreEqual(2147483648, convertedValue);

            Assert.AreEqual(typeof(long), StringConverter.ConvertString("-2147483649", out convertedValue));
            Assert.IsTrue(convertedValue is long);
            Assert.AreEqual(-2147483649, convertedValue);

            Assert.AreEqual(typeof(long), StringConverter.ConvertString("9223372036854775807", out convertedValue));
            Assert.IsTrue(convertedValue is long);
            Assert.AreEqual(9223372036854775807, convertedValue);


            Assert.AreEqual(typeof(ulong), StringConverter.ConvertString("9223372036854775808", out convertedValue));
            Assert.IsTrue(convertedValue is ulong);
            Assert.AreEqual(9223372036854775808, convertedValue);

            Assert.AreEqual(typeof(ulong), StringConverter.ConvertString("18446744073709551615", out convertedValue));
            Assert.IsTrue(convertedValue is ulong);
            Assert.AreEqual(18446744073709551615, convertedValue);


            Assert.AreEqual(typeof(float), StringConverter.ConvertString("18446744073709551616", out convertedValue));
            Assert.IsTrue(convertedValue is float);
            Assert.AreEqual(18446744073709551616F, convertedValue);

            Assert.AreEqual(typeof(float), StringConverter.ConvertString("2E16", out convertedValue));
            Assert.IsTrue(convertedValue is float);
            Assert.AreEqual(2E16F, convertedValue);

            Assert.AreEqual(typeof(float), StringConverter.ConvertString("1.7634E-16", out convertedValue));
            Assert.IsTrue(convertedValue is float);
            Assert.AreEqual(1.7634E-16F, convertedValue);

            Assert.AreEqual(typeof(float), StringConverter.ConvertString("-1.5E-45", out convertedValue));
            Assert.IsTrue(convertedValue is float);
            Assert.AreEqual(-1.5E-45F, convertedValue);

            Assert.AreEqual(typeof(float), StringConverter.ConvertString("1.5E-45", out convertedValue));
            Assert.IsTrue(convertedValue is float);
            Assert.AreEqual(1.5E-45F, convertedValue);


            // Not sure how to find a number that will get parsed by float.TryParse() but not double.TryParse()
            // which means FindStringType() may never actually return typeof(double)

            Assert.AreEqual(typeof(bool), StringConverter.ConvertString("true", out convertedValue));
            Assert.IsTrue(convertedValue is bool);
            Assert.IsTrue((bool)convertedValue);

            Assert.AreEqual(typeof(bool), StringConverter.ConvertString("TRUE", out convertedValue));
            Assert.IsTrue(convertedValue is bool);
            Assert.IsTrue((bool)convertedValue);

            Assert.AreEqual(typeof(bool), StringConverter.ConvertString("True", out convertedValue));
            Assert.IsTrue(convertedValue is bool);
            Assert.IsTrue((bool)convertedValue);

            Assert.AreEqual(typeof(bool), StringConverter.ConvertString("false", out convertedValue));
            Assert.IsTrue(convertedValue is bool);
            Assert.IsFalse((bool)convertedValue);

            Assert.AreEqual(typeof(bool), StringConverter.ConvertString("False", out convertedValue));
            Assert.IsTrue(convertedValue is bool);
            Assert.IsFalse((bool)convertedValue);

            Assert.AreEqual(typeof(bool), StringConverter.ConvertString("FALSE", out convertedValue));
            Assert.IsTrue(convertedValue is bool);
            Assert.IsFalse((bool)convertedValue);


            Assert.AreEqual(typeof(char), StringConverter.ConvertString("x", out convertedValue));
            Assert.IsTrue(convertedValue is char);
            Assert.AreEqual('x', convertedValue);

            Assert.AreEqual(typeof(char), StringConverter.ConvertString("\t", out convertedValue));
            Assert.IsTrue(convertedValue is char);
            Assert.AreEqual('\t', convertedValue);

            Assert.AreEqual(typeof(char), StringConverter.ConvertString(" ", out convertedValue));
            Assert.IsTrue(convertedValue is char);
            Assert.AreEqual(' ', convertedValue);

            Assert.AreEqual(typeof(char), StringConverter.ConvertString("\n", out convertedValue));
            Assert.IsTrue(convertedValue is char);
            Assert.AreEqual('\n', convertedValue);

            Assert.AreEqual(typeof(string), StringConverter.ConvertString("\n\n", out convertedValue));
            Assert.IsTrue(convertedValue is string);
            Assert.AreEqual("\n\n", convertedValue);

            Assert.AreEqual(typeof(string), StringConverter.ConvertString("wxyz", out convertedValue));
            Assert.IsTrue(convertedValue is string);
            Assert.AreEqual("wxyz", convertedValue);

            Assert.AreEqual(typeof(string), StringConverter.ConvertString("$3.85", out convertedValue));
            Assert.IsTrue(convertedValue is string);
            Assert.AreEqual("$3.85", convertedValue);

            Assert.AreEqual(typeof(string), StringConverter.ConvertString("", out convertedValue));
            Assert.IsTrue(convertedValue is string);
            Assert.AreEqual("", convertedValue);

        }


        [Test]
        public void TestCommonType()
        {
            object value1;
            object value2;
            Type typeA;
            Type typeB;

            typeA = StringConverter.ConvertString("\n", out value1);
            typeB = StringConverter.ConvertString("\n\n", out value2);
            Assert.AreEqual(typeof(string), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(string), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("x", out value1);
            typeB = StringConverter.ConvertString("xyz", out value2);
            Assert.AreEqual(typeof(string), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(string), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString(" ", out value1);
            typeB = StringConverter.ConvertString("\n", out value2);
            Assert.AreEqual(typeof(char), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(char), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("123", out value1);
            typeB = StringConverter.ConvertString("210", out value2);
            Assert.AreEqual(typeof(byte), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(byte), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("123", out value1);
            typeB = StringConverter.ConvertString("456", out value2);
            Assert.AreEqual(typeof(short), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(short), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("123", out value1);
            typeB = StringConverter.ConvertString("45678", out value2);
            Assert.AreEqual(typeof(int), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(int), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("123", out value1);
            typeB = StringConverter.ConvertString("456784567845678", out value2);
            Assert.AreEqual(typeof(long), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(long), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("123", out value1);
            typeB = StringConverter.ConvertString("18446744073709551615", out value2);
            Assert.AreEqual(typeof(ulong), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(ulong), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("123", out value1);
            typeB = StringConverter.ConvertString("123.0", out value2);
            Assert.AreEqual(typeof(float), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(float), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("18446744073709551615", out value1);
            typeB = StringConverter.ConvertString("123.0", out value2);
            Assert.AreEqual(typeof(float), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(float), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("18446744073709551615184467440737095516151844674407370955161518446744073709551615", out value1);
            typeB = StringConverter.ConvertString("123.0", out value2);
            Assert.AreEqual(typeof(double), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(double), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("18446744073709551615184467440737095516151844674407370955161518446744073709551615", out value1);
            typeB = StringConverter.ConvertString("xyzabc", out value2);
            Assert.AreEqual(typeof(string), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(string), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("true", out value1);
            typeB = StringConverter.ConvertString("false", out value2);
            Assert.AreEqual(typeof(bool), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(bool), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("123.456E-48", out value1);
            typeB = StringConverter.ConvertString("false", out value2);
            Assert.AreEqual(typeof(string), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(string), StringConverter.FindCommonType(typeB, typeA));

            typeA = StringConverter.ConvertString("true", out value1);
            typeB = StringConverter.ConvertString("\n", out value2);
            Assert.AreEqual(typeof(string), StringConverter.FindCommonType(typeA, typeB));
            Assert.AreEqual(typeof(string), StringConverter.FindCommonType(typeB, typeA));
        }
    }
}
