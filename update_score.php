<?php
$con = mysqli_connect('localhost', 'root', 'root', 'mydatabase');

    $username = $_POST["username"];
    $tasks_solved = $_POST["tasks_solved"];

    if(mysqli_connect_errno())
    {
        echo "Connection failed";
        exit();
    }
    echo "$tasks_solved";
    echo $username;
    $selectquery = "UPDATE employees SET tasks_solved = $tasks_solved WHERE username = '" . $username . "';";

    $result = $con->query($selectquery);

   
?>