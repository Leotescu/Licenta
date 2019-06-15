<?php
$con = mysqli_connect('localhost', 'root', 'root', 'mydatabase');

	if(mysqli_connect_errno())
	{
		echo "Connection failed";
		exit();
	}
	
	$selectquery = "SELECT username, position, tasks_solved FROM employees";

	$result = $con->query($selectquery);

	if($result->num_rows > 0) {

		while($row = $result->fetch_assoc()){
			echo  $row["username"]. "$" .$row["position"]. "$"  .$row["tasks_solved"]. "*";
		}
	} 

	
?>