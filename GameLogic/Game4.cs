﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
public class Game4 
    {
        private int[,] _matrix4 = new int[4,4];
        private bool[,] _stats4 = new bool[4, 4];
        private List<string> _dataList;

        public Game4(List<string> dataList)
        {
            _dataList = dataList;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _matrix4[i, j] = 0;
                    _stats4[i, j] = true; 
                }
            }

            foreach (string item in _dataList)
            {
                string[] temp = item.Split(' ');
                int row = int.Parse(temp[0]);
                int col = int.Parse(temp[1]);
                int val = int.Parse(temp[2]);
                _matrix4[row, col] = val;
            }
        }

        public string Test()
        {
            string temp = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp = temp + _matrix4[i, j] + " ";
                }
                temp += "\n";
            }
            temp += "\n";
            return temp;
        }

        public string BoolTest()
        {
            string temp = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp = temp + _stats4[i, j] + " ";
                }
                temp += "\n";
            }
            temp += "\n";
            return temp;
        }

        public void ValueChange(int row, int col, int val)
        {
            _matrix4[row, col] = val;
        }

        public bool TestRow(int row, int col)
        {
            int cnt = 0;
            for (int i = 0; i < 4; i++)
            {
                if (_matrix4[row, col] == _matrix4[row, i])
                    cnt++;
            }
            if (cnt > 1 && _matrix4[row, col] != 0)
                return false;
            else
                return true;
        }

        public bool TestCol(int row, int col)
        {
            int cnt = 0;
            for (int i = 0; i < 4; i++)
            {
                if (_matrix4[row, col] == _matrix4[i,col])
                    cnt++;
            }
            if (cnt > 1 && _matrix4[row, col] != 0)
                return false;
            else
                return true;
        }

        public bool TestBlock(int row, int col)
        {
            int blockX = row / 2;
            int blockY = col / 2;
            int cnt = 0;
            for (int i = blockX*2; i < blockX*2 + 2; i++){
                for (int j = blockY * 2; j < blockY * 2 + 2; j++)
                {
                    if (_matrix4[row, col] == _matrix4[i, j])
                        cnt++;
                }
            }
            if (cnt > 1 && _matrix4[row, col] != 0)
                return false;
            else
                return true;

        }
        
        

        public bool TestValid(int row, int col)
        {
            if (TestRow(row, col) && TestCol(row, col) && TestBlock(row, col))
            {
                _stats4[row, col] = true;
                return true;
            }
            else
            {
                _stats4[row, col] = false;
                return false;
            }
        }

        public bool TestComplete()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_matrix4[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        public bool TestWin()
        {
            if (TestComplete())
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (_stats4[i, j] == false)
                            return false;
                    }
                    Console.Write("\n");
                }
                return true;
            }
            else
                return false;
        }
        


    }
}
