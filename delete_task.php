<?php

	$status = $_REQUEST['status'];

	$con = mysqli_connect('localhost', 'root', 'root', 'mydatabase');

	if(mysqli_connect_errno())
	{
	echo "Connection failed";
	exit();
	}
	$title = $_POST["title"];
	$status = $_POST["status"];

	$sql = "UPDATE tasks SET
	status = 'Finish' WHERE status = 'InProgress'"; 

	$result = $con->query($sql);

?>