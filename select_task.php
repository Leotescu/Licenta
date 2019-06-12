<?php
$con = mysqli_connect('localhost', 'root', 'root', 'mydatabase');

	if(mysqli_connect_errno())
	{
		echo "Connection failed";
		exit();
	}
	
	$selectquery = "SELECT  title, username, deadline, status FROM tasks";

	$result = $con->query($selectquery);

	if($result->num_rows > 0) {

		while($row = $result->fetch_assoc()){
			echo  $row["title"]. " "  .$row["deadline"]. " " .$row["username"].  " " .$row["status"]. "*";
		}
	} else {
		echo "0 result";
	}
	
?>