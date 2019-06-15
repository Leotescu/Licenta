<?php
$con = mysqli_connect('localhost', 'root', 'root', 'mydatabase');

	if(mysqli_connect_errno())
	{
		echo "Connection failed";
		exit();
	}

	$username = $_POST["username"];
	$position = $_POST["position"];
	$password = $_POST["password"];

	$namecheckquery = "SELECT username, position, salt, hash, tasks_solved FROM employees WHERE username = '" . $username . "'
	AND position = '" . $position . "'; ";

	$namecheck = mysqli_query($con, $namecheckquery) or die("Name check query failed");

	if(mysqli_num_rows($namecheck) != 1)
	{
		echo "User not exist";
		exit();
	}

	$existinginfo = mysqli_fetch_assoc($namecheck);
	$salt = $existinginfo["salt"];
	$hash = $existinginfo["hash"];

	$loginhash = crypt($password, $salt);
	if ($hash != $loginhash)
	{
		echo "Incorrect password";
		exit();
	}

	echo "0\t" . $existinginfo["tasks_solved"]
?>