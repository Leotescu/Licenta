<?php
$con = mysqli_connect('localhost', 'root', 'root', 'mydatabase');

	if(mysqli_connect_errno())
	{
		echo "Connection failed";
		exit();
	}

	$title = $_POST["title"];
	$deadline = $_POST["deadline"];
	$description = $_POST["description"];
	$username = $_POST["username"];
	$status = $_POST["status"];
	$today = date("Y-m-d");

	$namecheckquery = "SELECT title FROM tasks WHERE title =
	'" . $title . "';";

	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed");

	if(mysqli_num_rows($namecheck) > 0)
	{
		echo "Task already exists";
		exit();
	}

	$today_dt = new DateTime($today);
	$deadline_dt = new DateTime($deadline);

	if($deadline_dt < $today_dt)
	{
		echo "Date is incorrect";
		exit();
	}

	$namecheckexistquery = "SELECT username FROM employees WHERE username = 
	'" . $username . "';";

	$namecheckexist = mysqli_query($con, $namecheckexistquery) or die("2: Username check query failed");

	if(mysqli_num_rows($namecheckexist) != 1)
	{
		echo "Username not exist";
		exit();
	}

	$insertuserquery = "INSERT INTO tasks (id, title, deadline, description, username, status ) VALUES (NULL, '" . $title . "', '" . $deadline . "', '" . $description . "', '" . $username . "', '" . $status . "');";
	mysqli_query($con, $insertuserquery) or die("Insert task query failed");

	echo "0";
	
?>