#pragma strict

var speed 				: float = 5.0f;
var xRange				: float = 10.0f;	// move [range] units to the left and the right
var yScale 				: float = 2.0f;

private var startPos 	: Vector3;
private var direction 	: int 	= 1;
private var leftBorder 	: float = 0.0f;
private var rightBorder : float = 0.0f;

function Start () {
	startPos = this.transform.position;
	leftBorder = startPos.x - xRange;
	rightBorder = startPos.x + xRange;
}

function Update () {
	var xCurrent = this.transform.position.x;
	
	if ((xCurrent > rightBorder && direction == 1) ||
		(xCurrent < leftBorder && direction == -1)) 
	{
		direction *= -1;
	}
	
	this.transform.position.x += direction * speed * Time.deltaTime;
	this.transform.position.y = startPos.y + Mathf.Sin(this.transform.position.x) * yScale;
}