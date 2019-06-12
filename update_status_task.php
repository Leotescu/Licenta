<?php

$con = mysqli_connect('localhost', 'root', 'root', 'mydatabase');

	$title = $_POST["title"];
	$status = $_POST["status"];
	

	if(mysqli_connect_errno())
	{
		echo "Connection failed";
		exit();
	}
	

	$selectquery = "UPDATE tasks SET status = 'InProgress'  WHERE title ='" . $title . "';";

	$result = mysqli_query($con, $selectquery);
	
?>