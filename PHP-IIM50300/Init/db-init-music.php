<?php

$servername = "mysql.labranet.jamk.fi";
$username = "H3298";
$password = "dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB";
$dbname = "H3298_1";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 
?>