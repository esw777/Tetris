/*
 * Project: Tetris
 * FileName: ShapeMaker.cs
 * Author: Eric W.
 * Date Created 1/6/2015
 * Rights reserved.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShapeMaker : MonoBehaviour //rename this to shapeController later
{
	enum ShapeType
	{
		JShape = 0,
		LShape,
		ZShape,
		SShape,
		SquareShape,
		LineShape,
		TShape
	};

	public enum Direction
	{
		Down = 0,
		Left,
		Right,
		Rotate
	};

	private Material greenMat;
	private Material redMat;
	private Material yellowMat;
	private Material blueMat;
	private Material magentaMat;
	private Material whiteMat;
	private Material cyanMat;

	GameObject pivot;
		
	private int m_startHeight;
	private int m_startWidth;

	private bool activeShape;
	private int currentRotation;

	private List<GameObject> shapeList;

	public void initShapeMaker(GameBoard in_gameBoard)
	{
		//Debug.Log("initShapeMaker start");
		greenMat = new Material(Shader.Find("Diffuse"));
		redMat = new Material(Shader.Find("Diffuse"));
		yellowMat = new Material(Shader.Find("Diffuse"));
		blueMat = new Material(Shader.Find("Diffuse"));
		magentaMat = new Material(Shader.Find("Diffuse"));
		whiteMat = new Material(Shader.Find("Diffuse"));
		cyanMat = new Material(Shader.Find("Diffuse"));
		
		greenMat.color = Color.green;
		redMat.color = Color.red;
		yellowMat.color = Color.yellow;
		blueMat.color = Color.blue;
		magentaMat.color = Color.magenta;
		whiteMat.color = Color.white;
		cyanMat.color = Color.cyan;

		pivot = new GameObject("RotateAround");

		int gb_width = in_gameBoard.getWidth();
		int gb_height = in_gameBoard.getHeight();
		m_startHeight = gb_height - 4; //spawn 4 blocks from top.
		m_startWidth = gb_width / 2; //spawn in middle of board

		activeShape = false;
		currentRotation = 0;

		shapeList = new List<GameObject>(); // shapeObject

		//Debug.Log("initShapeMaker end");
	} // end initShapeMaker

	public void spawnShape()
	{
		int randomValue = Random.Range(0,7);
		currentRotation = 0; //reset rotation for new shapes.

		switch ((ShapeType)randomValue)
		{
		case ShapeType.JShape:
		{		
			pivot.transform.position = new Vector3(m_startWidth,m_startHeight+1, 0);
			
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight,0), redMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth-1, m_startHeight,0), redMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+1,0), redMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+2,0), redMat));

			break;	
		}

		case ShapeType.LShape:
		{
			pivot.transform.position = new Vector3(m_startWidth,m_startHeight+2, 0);
			
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight,0), greenMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth+1, m_startHeight,0), greenMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+1,0), greenMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+2,0), greenMat));
			
			break;
		}

		case ShapeType.ZShape:
		{
			pivot.transform.position = new Vector3(m_startWidth,m_startHeight+1, 0);
			
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight,0), yellowMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth+1, m_startHeight,0), yellowMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+1,0), yellowMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth-1, m_startHeight+1,0), yellowMat));

			break;
		}

		case ShapeType.SShape:
		{
			pivot.transform.position = new Vector3(m_startWidth,m_startHeight+1, 0);
			
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight,0), blueMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth-1, m_startHeight,0), blueMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+1,0), blueMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth+1, m_startHeight+1,0), blueMat));
			
			break;
		}

		case ShapeType.SquareShape:
		{
			pivot.transform.position = new Vector3(m_startWidth+0.5f,m_startHeight+0.5f, 0);
			
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight,0), magentaMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth+1, m_startHeight,0), magentaMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+1,0), magentaMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth+1, m_startHeight+1,0), magentaMat));
			
			break;
		}
			
		case ShapeType.LineShape:
		{
			pivot.transform.position = new Vector3(m_startWidth+0.5f,m_startHeight+1.5f, 0);
			
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight,0), whiteMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+1,0), whiteMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+2,0), whiteMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+3,0), whiteMat));
			
			break;
		}

		case ShapeType.TShape:
		{
			pivot.transform.position = new Vector3(m_startWidth,m_startHeight+1, 0);
			
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight,0), cyanMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth-1, m_startHeight,0), cyanMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth+1, m_startHeight), cyanMat));
			shapeList.Add(GenBlock(new Vector3(m_startWidth, m_startHeight+1), cyanMat));
			
			break;
		}
			
		default:
		{
			break;
		}

		} //end of switch

		activeShape = true;

	} //end spawnShape


	private GameObject GenBlock(Vector3 in_pos, Material in_mat)
	{	
		GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		obj.name = "Block";
		obj.tag = "block";
		obj.transform.position = in_pos;
		obj.renderer.material = in_mat;

		return obj;
	} //end GenBlock

	public void moveShape(GameBoard in_gameBoard, Direction in_direction)
	{
		if (shapeList.Count != 4 || !activeShape)
		{
			//Debug.Log("MoveShape called with no block spawned");
		}

		else
		{
			//Get current shape position
			Vector3 block1 = shapeList[0].transform.position;
			Vector3 block2 = shapeList[1].transform.position; 
			Vector3 block3 = shapeList[2].transform.position;
			Vector3 block4 = shapeList[3].transform.position;
			bool validMove = false;

			switch (in_direction)
			{
				case Direction.Down:
				{
					//check that shape can move down 1
					validMove = CheckValidMoveDown(block1, in_gameBoard) && 
								CheckValidMoveDown(block2, in_gameBoard) && 
								CheckValidMoveDown(block3, in_gameBoard) && 
								CheckValidMoveDown(block4, in_gameBoard);
					
					if (validMove)
					{
						//Move the block down.
						block1 = new Vector3(Mathf.RoundToInt(block1.x),Mathf.RoundToInt(block1.y-1.0f),block1.z);
						block2 = new Vector3(Mathf.RoundToInt(block2.x),Mathf.RoundToInt(block2.y-1.0f),block2.z);
						block3 = new Vector3(Mathf.RoundToInt(block3.x),Mathf.RoundToInt(block3.y-1.0f),block3.z);
						block4 = new Vector3(Mathf.RoundToInt(block4.x),Mathf.RoundToInt(block4.y-1.0f),block4.z);
						
						pivot.transform.position = new Vector3(pivot.transform.position.x, pivot.transform.position.y-1, pivot.transform.position.z);
						
						//update shape position
						shapeList[0].transform.position = block1;
						shapeList[1].transform.position = block2; 
						shapeList[2].transform.position = block3; 
						shapeList[3].transform.position = block4; 
					}
					
					else
					{
						//Hit a block or bottom of level
						//add shape permanantly to gameBoard.
						in_gameBoard.requestAddBlock(Mathf.RoundToInt(block1.x),Mathf.RoundToInt(block1.y));
						in_gameBoard.requestAddBlock(Mathf.RoundToInt(block2.x),Mathf.RoundToInt(block2.y));
						in_gameBoard.requestAddBlock(Mathf.RoundToInt(block3.x),Mathf.RoundToInt(block3.y));
						in_gameBoard.requestAddBlock(Mathf.RoundToInt(block4.x),Mathf.RoundToInt(block4.y));

						int rowsCleared = 0;

						//check for full rows
						rowsCleared += in_gameBoard.checkIfFullRow(Mathf.RoundToInt(block1.y));
						rowsCleared += in_gameBoard.checkIfFullRow(Mathf.RoundToInt(block2.y));
						rowsCleared += in_gameBoard.checkIfFullRow(Mathf.RoundToInt(block3.y));
						rowsCleared += in_gameBoard.checkIfFullRow(Mathf.RoundToInt(block4.y));
				
						//remove active shape object
						shapeList.Clear(); 
						activeShape = false;
					}
					break;
				} //end case down

				case Direction.Left:
				{
					//check that shape can move left 1
					validMove = CheckValidMoveLeft(block1, in_gameBoard) && 
								CheckValidMoveLeft(block2, in_gameBoard) && 
								CheckValidMoveLeft(block3, in_gameBoard) && 
								CheckValidMoveLeft(block4, in_gameBoard);
					
					if (validMove)
					{
						//Move the block left.
						block1 = new Vector3(Mathf.RoundToInt(block1.x-1.0f),Mathf.RoundToInt(block1.y),block1.z);
						block2 = new Vector3(Mathf.RoundToInt(block2.x-1.0f),Mathf.RoundToInt(block2.y),block2.z);
						block3 = new Vector3(Mathf.RoundToInt(block3.x-1.0f),Mathf.RoundToInt(block3.y),block3.z);
						block4 = new Vector3(Mathf.RoundToInt(block4.x-1.0f),Mathf.RoundToInt(block4.y),block4.z);
						
						pivot.transform.position = new Vector3(pivot.transform.position.x-1, pivot.transform.position.y, pivot.transform.position.z);

						//update shape position
						shapeList[0].transform.position = block1;
						shapeList[1].transform.position = block2; 
						shapeList[2].transform.position = block3; 
						shapeList[3].transform.position = block4; 
					}

					else
					{
						//dont move
					}
					break;
				} // end case left

				case Direction.Right:
				{
					//check that shape can move right 1
					validMove = CheckValidMoveRight(block1, in_gameBoard) && 
								CheckValidMoveRight(block2, in_gameBoard) && 
								CheckValidMoveRight(block3, in_gameBoard) && 
								CheckValidMoveRight(block4, in_gameBoard);
					
					if (validMove)
					{
						//Move the block right.
						block1 = new Vector3(Mathf.RoundToInt(block1.x+1.0f),Mathf.RoundToInt(block1.y),block1.z);
						block2 = new Vector3(Mathf.RoundToInt(block2.x+1.0f),Mathf.RoundToInt(block2.y),block2.z);
						block3 = new Vector3(Mathf.RoundToInt(block3.x+1.0f),Mathf.RoundToInt(block3.y),block3.z);
						block4 = new Vector3(Mathf.RoundToInt(block4.x+1.0f),Mathf.RoundToInt(block4.y),block4.z);
						
						pivot.transform.position = new Vector3(pivot.transform.position.x+1, pivot.transform.position.y, pivot.transform.position.z);
						
						//update shape position
						shapeList[0].transform.position = block1;
						shapeList[1].transform.position = block2; 
						shapeList[2].transform.position = block3; 
						shapeList[3].transform.position = block4; 
					}
					
					else
					{
						//dont move
					}
				break;
				} //end case right

				case Direction.Rotate:
				{
					//Check for valid rotation
					//If valid, block will be rotated inside of the check function
					CheckValidRotate(shapeList[0].transform, 
				                 	 shapeList[1].transform, 
				                 	 shapeList[2].transform, 
				                 	 shapeList[3].transform,
				                 		in_gameBoard); 
					break;
				}
				/* comment out cause compiler complains about unreachable code
				default:
				{
					Debug.Log ("Bad direction sent to moveShapeDown");
					break;
				}
				*/
			}//end of dir switch
		}		
	}//end moveShapeDown

	private bool CheckValidMoveDown(Vector3 in_block, GameBoard in_gameBoardDown)
	{
		bool validMove = false;

		//check position 1 below the block
		if(in_gameBoardDown.requestStatusOfPosition(Mathf.RoundToInt(in_block.x),Mathf.RoundToInt(in_block.y-1)) == 1)
		{
			//validMove = false;
		}

		else
		{
			validMove = true;
		}
		
		return validMove;		
	} //end CheckValidMoveDown

	private bool CheckValidMoveRight(Vector3 in_block, GameBoard in_gameBoardRight)
	{
		bool validMove = false;
		
		//check position 1 right of  the block
		if(in_gameBoardRight.requestStatusOfPosition(Mathf.RoundToInt(in_block.x+1),Mathf.RoundToInt(in_block.y)) == 1)
		{
			//validMove = false;
		}
		
		else
		{
			validMove = true;
		}
		
		return validMove;		
	} //end CheckValidMoveRight

	private bool CheckValidMoveLeft(Vector3 in_block, GameBoard in_gameBoardLeft)
	{
		bool validMove = false;
		
		//check position 1 left the block
		if(in_gameBoardLeft.requestStatusOfPosition(Mathf.RoundToInt(in_block.x-1),Mathf.RoundToInt(in_block.y)) == 1)
		{
			//validMove = false;
		}
		
		else
		{
			validMove = true;
		}
		
		return validMove;		
	} //end CheckValidMoveLeft
	
	public void CheckValidRotate(Transform in_block1, Transform in_block2, Transform in_block3, Transform in_block4, GameBoard in_gameBoardRotate)
	{
		in_block1.parent = pivot.transform;
		in_block2.parent = pivot.transform;
		in_block3.parent = pivot.transform;
		in_block4.parent = pivot.transform;

		currentRotation += 90;
		if (currentRotation == 360)
		{
			currentRotation = 0;
		}

		//rotate block
		pivot.transform.localEulerAngles = new Vector3(0,0, currentRotation);

		//check if rotation results in valid position.
		if(		(in_gameBoardRotate.requestStatusOfPosition(Mathf.RoundToInt(in_block1.position.x),Mathf.RoundToInt(in_block1.position.y)) == 1)
		    ||  (in_gameBoardRotate.requestStatusOfPosition(Mathf.RoundToInt(in_block2.position.x),Mathf.RoundToInt(in_block2.position.y)) == 1)
		    ||  (in_gameBoardRotate.requestStatusOfPosition(Mathf.RoundToInt(in_block3.position.x),Mathf.RoundToInt(in_block3.position.y)) == 1)
			||  (in_gameBoardRotate.requestStatusOfPosition(Mathf.RoundToInt(in_block4.position.x),Mathf.RoundToInt(in_block4.position.y)) == 1)
		   		)
		{
			//not valid, undo rotation
			currentRotation -= 90;
			pivot.transform.localEulerAngles = new Vector3(0,0, currentRotation);
		}

		in_block1.parent = null;
		in_block2.parent = null;
		in_block3.parent = null;
		in_block4.parent = null;
	}

	public bool getActiveShapeStatus()
	{
		return activeShape;
	} //end getActiveShapeStatus
}
