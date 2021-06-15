using System;
using System.Linq;
using System.Collections;
using System.Runtime.CompilerServices;

namespace FineChess_csharp
{
    class Program
    {
        public enum Sides
        {
            White, Black
        }


        public enum Letters
        {
            A, B, C, D, E, F, G, H
        }


        public enum Numbers
        {
            Number_1, Number_2, Number_3, Number_4, Number_5, Number_6, Number_7, Number_8
        }


        public enum Cells
        {
            a1, b1, c1, d1, e1, f1, g1, h1,
            a2, b2, c2, d2, e2, f2, g2, h2,
            a3, b3, c3, d3, e3, f3, g3, h3,
            a4, b4, c4, d4, e4, f4, g4, h4,
            a5, b5, c5, d5, e5, f5, g5, h5,
            a6, b6, c6, d6, e6, f7, g6, h6,
            a7, b7, c7, d7, e7, f6, g7, h7,
            a8, b8, c8, d8, e8, f8, g8, h8,
            Empty
        }


        public enum Pieces
        {
            Pawn, Rookie, Knight, Bishop, Queen, King, Empty
        }


        public enum Ways
        {
            Horizontal, Vertical, Diagonal
        }


        public abstract class Piece
        {
            public static readonly Pieces Empty = Pieces.Empty;
        }


        public sealed class Pawn : Piece
        {
            public Sides Side { get; }

            public Pawn(Sides side)
                => Side = side;
        }


        public readonly struct Cell
        {
            #region static attributes & methods
            public static readonly string[] CellPositionStrings;

            public static readonly Cell Empty = new(Cells.Empty);

            static Cell()
                => CellPositionStrings = Enum.GetNames(typeof(Cells));
            #endregion

            #region constructors & default implictors
            public Cell(int numOfCell)
                => Value = (Cells)numOfCell;

            public static implicit operator Cell(int numOfCell)
                => new(numOfCell);

            public Cell(Cells enumOfCell)
                => Value = enumOfCell;

            public static implicit operator Cell(Cells enumOfCell)
                => new(enumOfCell);

            public Cell(Cell cell)
                => Value = cell.Value;
            #endregion

            #region object attributes & methods
            public readonly Cells Value;

            public int AsInt()
                => (int)Value;
            #endregion

            #region implictors of default operators
            #endregion
        }


        public readonly struct Letter
        {
            #region static attributes & methods
            private static readonly char[] LetterChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            private static readonly string[] LetterStrings;

            static Letter()
                => LetterStrings = LetterChars.Select(ch => ch.ToString()).ToArray();
            #endregion

            #region constructors & default implictors
            public Letter(int numOfLetter)
                => Value = (Letters)numOfLetter;

            public static implicit operator Letter(int numOfLetter)
                => new(numOfLetter);

            public Letter(Letters enumOfLetter)
                => Value = enumOfLetter;

            public static implicit operator Letter(Letters enumOfLetter)
                => new(enumOfLetter);

            public Letter(Letter letter)
                => Value = letter.Value;
            #endregion

            #region object attributes & methods
            public readonly Letters Value;
            #endregion

            #region implictors of default operators
            #endregion
        }


        public readonly struct Number
        {

        }

        static void Main(string[] args)
        {
            Pawn piece = new(Sides.White);

            Cell c1 = new(0);
            Cell c2 = new(1);

            Console.WriteLine(c1.Value);
            Console.WriteLine(Cell.CellPositionStrings.Contains("a1"));
            Console.WriteLine(10 & 7);

            Console.ReadKey();
        }
    }
}
