using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Board
    {
        private readonly List<Cell> _cells;
        private readonly int _columns;
        private readonly int _rows;

        public Board(int rows, int columns, string initialState)
        {
            _rows = rows;
            _columns = columns;
            _cells = new List<Cell>();
            InitializeBoard(initialState);
        }

        public string GetNextGeneration()
        {
            var result = string.Empty;

            for (var rowNum = 0; rowNum < _rows; rowNum++)
            {
                for (var colNum = 0; colNum < _columns; colNum++)
                {
                    var cell = _cells.First(c => c.IsLocation(rowNum, colNum));
                    result += cell.GetState(GetAliveNeighborCount(rowNum, colNum));
                }
                result += '\n';
            }

            result = result.Trim('\n');

            return result;
        }

        private int GetAliveNeighborCount(int rowNum, int colNum)
        {
            return 0;

        }

        private void AddCell(int rowNum, int colNum, char contents)
        {
            var item = new Cell(rowNum, colNum, contents);
            _cells.Add(item);
        }

        private void InitializeBoard(string initialState)
        {
            var rowStrings = initialState.Split(' ');
            for (var rowNum = 0; rowNum < rowStrings.Length; rowNum++)
            {
                for (var colNum = 0; colNum < _columns; colNum++)
                {
                    AddCell(rowNum, colNum, rowStrings[rowNum][colNum]);
                }
            }
        }
    }

    public class Cell
    {
        private readonly int _col;
        private readonly char _contents;
        private readonly int _row;

        public Cell(int rowNum, int colNum, char contents)
        {
            _row = rowNum;
            _col = colNum;
            _contents = contents;
        }

        public char GetState(int neighborCount)
        {
            if(neighborCount == 3)
                return LiveCell;


            return DeadCell;
        }

        public bool IsLocation(int rowNum, int colNum)
        {
            return _row == rowNum && _col == colNum;
        }

        public const char DeadCell = '.';
        public const char LiveCell = '*';
    }
}
