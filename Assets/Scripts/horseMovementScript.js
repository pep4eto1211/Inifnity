#pragma strict

var speed = 5.0f;
var range = 10.0f;					// move [range] units to the left and the right

private var xStart = 0.0f;
private var direction = 1;

function Start () {
	xStart = this.transform.position.x;
}

function Update () {
	var xCurrent = this.transform.position.x;
	
	if((xCurrent >= xStart + range) || (xCurrent <= xStart - range)) {
		direction *= -1;
	}
	
	this.transform.position.x += direction * speed * Time.deltaTime;
}