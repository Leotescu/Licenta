<?php

	$con = mysqli_connect('localhost', 'root', 'root', 'mydatabase');

	if(mysqli_connect_errno())
	{
		echo "1: Connection failed";
		exit();
	}

	$firstname = $_POST["firstname"];
	$lastname = $_POST["lastname"];
	$username = $_POST["username"];
	$position = $_POST["position"];
	$password = $_POST["password"];


	$namecheckquery = "SELECT username FROM employees WHERE username =
	'" . $username . "';";

	$namecheck = mysqli_query($con, $namecheckquery) or die("2: Name check query failed");

	if(mysqli_num_rows($namecheck) > 0)
	{
		echo "3 Name already exists";
		exit();
	}

	$salt = "\$5\$rounds=5000\$" . "steamedhams" . $username . "\$";
	$hash = crypt($password, $salt);
	$insertuserquery = "INSERT INTO employees (id, username, lastname, firstname, position, hash, salt, tasks_solved ) VALUES (NULL, '" . $username . "', '" . $lastname . "', '" . $firstname . "', '" . $position . "', '" . $hash . "', '" . $salt . "', '0');";
	mysqli_query($con, $insertuserquery) or die("4: Insert employee query failed");

	echo "0";

?>