<?php
$con = mysqli_connect('localhost', 'root', 'root', 'mydatabase');

	if(mysqli_connect_errno())
	{
		echo "1: Connection failed";
		exit();
	}

	$title = $_POST["title"];
	$deadline = $_POST["deadline"];
	$description = $_POST["description"];
	$username = $_POST["username"];
	
	$namecheckquery = "SELECT title FROM tasks WHERE title =
	'" . $title . "';";

	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed");

	if(mysqli_num_rows($namecheck) > 0)
	{
		echo "3 Task already exists";
		exit();
	}

	$insertuserquery = "INSERT INTO tasks (id, title, deadline, description, username ) VALUES (NULL, '" . $title . "', '" . $deadline . "', '" . $description . "', '" . $username . "');";
	mysqli_query($con, $insertuserquery) or die("4: Insert task query failed");

	echo "0";
	
?>