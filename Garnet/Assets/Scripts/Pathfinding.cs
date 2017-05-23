using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour {

	public Transform seeker, target;
	Grid grid;

	void Awake()
	{
		grid = GetComponent<Grid> ();
	}

	void Update()
	{
		findPath (seeker.position, target.position);
	}

	void findPath(Vector3 startPos, Vector3 endPos)
	{
		Node startNode = grid.NodeFromWorldPoint (startPos);
		Node targetNode = grid.NodeFromWorldPoint (endPos);

		Heap<Node> openSet = new Heap<Node> (grid.MaxSize);
		HashSet<Node> closedSet = new HashSet<Node> ();
		openSet.Add (startNode);

		while (openSet.Count > 0) 
		{
			
			Node currentNode = openSet.RemoveFirst ();
			closedSet.Add (currentNode);

			if (currentNode == targetNode) 
			{
				retracePath (startNode, targetNode);
				return;
			}

			foreach (Node neighbor in grid.getNeighbors(currentNode)) 
			{
				if (!neighbor.walkable || closedSet.Contains (neighbor))
					continue;

				int newMovementCost = currentNode.gCost + getDistance (currentNode, neighbor);
				if (newMovementCost < neighbor.gCost || !openSet.Contains (neighbor)) 
				{
					neighbor.gCost = newMovementCost;
					neighbor.hCost = getDistance (neighbor, targetNode);
					neighbor.parent = currentNode;

					if (!openSet.Contains (neighbor)) {
						openSet.Add (neighbor);
					} else {
						openSet.UpdateItem (neighbor);
					}
				}
			}
		}
	}

	void retracePath(Node startNode, Node targetNode)
	{
		List<Node> path = new List<Node> ();

		Node currentNode = targetNode;

		while (currentNode != startNode) 
		{
			path.Add (currentNode);
			currentNode = currentNode.parent;
		}

		path.Reverse();
		grid.path = path;
	}

	int getDistance(Node a, Node b)
	{
		int dstX = Mathf.Abs (a.gridX - b.gridX);
		int dstY = Mathf.Abs (a.gridY - b.gridY);

		//print ("getting distance");
		return (dstX > dstY) ? (14 * dstY + 10 * (dstX - dstY)) : (14 * dstX + 10 * (dstY - dstX));
	}
}
