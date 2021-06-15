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


        public enum Ways
        {
            Horizontal, Vertical, Diagonal
        }


        public abstract class Piece
        {
            public enum Types
            {
                Pawn, Rookie, Knight, Bishop, Queen, King, Empty
            }

            public abstract Types Type { get; }

            public bool IsNotEmpty => Type != Types.Empty;
        }


        public sealed class Pawn : Piece
        {
            public override Types Type => Types.Pawn;
            public Sides Side { get; }

            public Pawn(Sides side)
            {
                Side = side;
            }
        }


        public sealed class Empty : Piece
        {
            public override Types Type => Types.Empty;
        }


        public readonly struct Cell
        {
            public static readonly string[] CellPositionStrings;

            public static readonly Cell Empty = new(Cells.Empty);

            static Cell()
                => CellPositionStrings = Enum.GetNames(typeof(Cells));

            public Cell(int numberOfCell)
                => Value = (Cells)numberOfCell;
            public static implicit operator Cell(int numberOfCell)
                => new(numberOfCell);

            public Cell(Cells cell)
                => Value = cell;
            public static implicit operator Cell(Cells cell)
                => new(cell);

            public Cell(Cell cell)
                => Value = cell.Value;

            public readonly Cells Value;
        }


        public readonly struct Letter
        {
            private static readonly char[] LetterChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

            private static readonly string[] LetterStrings;

            static Letter()
                => LetterStrings = LetterChars.Select(ch => ch.ToString()).ToArray();
        }


        public readonly struct Number
        {

        }

        static void Main(string[] args)
        {
            Pawn piece = new(Sides.White);
            Console.WriteLine("{0} {1}", piece.Side, piece.Type);

            Cell c1 = new(0);
            Cell c2 = new(1);

            Console.WriteLine(c1.Value);

            Console.WriteLine(Cell.CellPositionStrings.Contains("a1"));

            Console.ReadKey();
        }
    }
}
