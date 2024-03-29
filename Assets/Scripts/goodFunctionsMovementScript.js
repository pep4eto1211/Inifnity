﻿#pragma strict

var speed 				: float = 5.0f;
var xRange				: float = 10.0f;	// move [range] units to the left and the right

private var xStart 		: float = 0.0f;
private var direction 	: int 	= 1;
private var leftBorder 	: float = 0.0f;
private var rightBorder : float = 0.0f;

function Start () {
	xStart = this.transform.position.x;
	leftBorder = xStart - xRange;
	rightBorder = xStart + xRange;
}

function Update () {
	var xCurrent = this.transform.position.x;
	
	if ((xCurrent > rightBorder && direction == 1) ||
		(xCurrent < leftBorder && direction == -1)) 
	{
		direction *= -1;
	}
	
	this.transform.position.x += direction * speed * Time.deltaTime;
}