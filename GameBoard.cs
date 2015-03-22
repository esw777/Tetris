/*
 * Project: Tetris
 * FileName: GameBoard.cs
 * Author: Eric W.
 * Date Created 1/6/2015
 * Rights reserved.
 */

using UnityEngine;
using System.Collections;

public class GameBoard : MonoBehaviour
{
	private int m_width = 0;
	private int m_height = 0;
	private int [,] board;
	private bool gameOver;

	public GameBoard()
	{

	}
	
	public void initGameBoard(int in_width, int in_height)
	{
		Debug.Log("initGB board start");
		m_width = in_width;
		m_height = in_height;

		gameOver = false;

		board = new int[m_width,m_height];

		//Materials for cubes.
		Material grayMat = new Material(Shader.Find("Diffuse"));
		grayMat.color = Color.grey;	
		Material blackMat = new Material(Shader.Find("Diffuse"));
		blackMat.color = Color.black;

		Debug.Log("IntitGB start of generation");
		//Create array of flat cubes (squares) to serve as game board.
		for (int x = 0; x < m_width; x++)
		{
			for (int y = 0; y < m_height; y++)
			{
				//Side edges
				if (x == 0 || x == m_width-1)
				{
					board[x,y] = 1;
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.transform.position = new Vector3(x, y, 0);
					cube.renderer.material = grayMat;
					cube.name = "wallPiece";
				}

				//bottom edge
				else if (y == 0)
				{
					board[x,y] = 1;
					GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					cube.transform.position = new Vector3(x, y, 0);
					cube.renderer.material = blackMat;
					cube.name = "floorPiece";
				}

				//middle - non edge - not needed.
				else
				{

				}
			} //end of y for
		} // end of x for
	} // end of init

	public int getHeight()
	{
		return m_height;
	}

	public int getWidth()
	{
		return m_width;
	}

	public void requestRemoveBlock(int in_x, int in_y)
	{
		board[in_x, in_y] = 0;
	}

	public void requestAddBlock(int in_x, int in_y)
	{
		board[in_x, in_y] = 1;
	}

	public int requestStatusOfPosition(int in_x, int in_y)
	{
		int returnValue = 1;
		//is position empty or occupied
		if (in_y <= 0 || in_x <= 0 || in_x >= m_width-1 || in_y >= m_height)
		{
			returnValue = 1;
		}

		else
		{
			returnValue = board[in_x, in_y];
		}
		return returnValue;
	}

	//returns number of rows cleared.
	public int checkIfFullRow(int y)
	{
		int rowsCleared = 0;
		int blockCount = 0;

		for (int x = 0; x < m_width; x++)
		{
			if (board[x,y] == 1)
			{
				blockCount++;
			}
		}

		if (blockCount == m_width)
		{
			//delete block on that row.
			deleteRow(y);

			//move any blocks above down 1 level.
			moveBlocksDown(y);

			//repeat check after block have fallen.
			rowsCleared += checkIfFullRow(y);
			rowsCleared++;
		}

		else
		{
			checkIfGameOver();
		}
		blockCount = 0;

		return rowsCleared;
	}

	private void deleteRow(int row)
	{
		GameObject[] blocks = GameObject.FindGameObjectsWithTag("block");

		foreach(GameObject tmpGO in blocks)
		{
			int yPos = Mathf.RoundToInt(tmpGO.transform.position.y);
			int xPos = Mathf.RoundToInt(tmpGO.transform.position.x);

			//delete block
			if (yPos == row)
			{
				board[xPos, yPos] = 0;
				Destroy(tmpGO.gameObject);
			}

			//move block down 1
			else if (yPos > row)
			{
				tmpGO.transform.position = new Vector3(xPos, yPos-1, tmpGO.transform.position.z);
			}

			else
			{

			}
		}
	}

	private void moveBlocksDown(int row)
	{
		for (int x = 1; x < m_width-1; x++)
		{
			for (int y = row; y < m_height-4; y++)
			{
				board[x, y] = board[x, y+1];
			}
		}
	}

	private void checkIfGameOver()
	{
		for (int x = 1; x < m_width-1; x++)
		{
			if (board[x, m_height-4] == 1)
			{
				gameOver = true;
			}
		}
	}

	public bool getGameOver()
	{
		return gameOver;
	}
}
















