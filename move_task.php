<?php

$con = mysqli_connect('localhost', 'root', 'root', 'mydatabase');

	$title = $_POST["title"];
	$actual_username = $_POST["actual_username"];
	$new_username = $_POST["new_username"];

	if(mysqli_connect_errno())
	{
		echo "Connection failed";
		exit();
	}
	

	$selectquery = "UPDATE tasks SET username = '$new_username'  WHERE title ='" . $title . "';";

	$result = mysqli_query($con, $selectquery);
	
?>