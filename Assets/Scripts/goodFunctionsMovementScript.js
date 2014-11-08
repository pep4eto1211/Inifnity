#pragma strict

var speed = 5.0f;
var range = 10.0f;					// move [range] units to the left and the right

private var xStart = 0.0f;
private var direction = 1;
private var leftBorder = 0.0f;
private var rightBorder = 0.0f;

function Start () {
	xStart = this.transform.position.x;
	leftBorder = xStart - range;
	rightBorder = xStart + range;
}

function Update () {
	var xCurrent = this.transform.position.x;
	
	if(xCurrent < leftBorder || xCurrent > rightBorder) {
		direction *= -1;
	}
	
	this.transform.position.x += direction * speed * Time.deltaTime;
}