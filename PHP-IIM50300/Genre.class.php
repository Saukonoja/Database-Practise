<?php
 
    class Genre{
        private $name;
 
        function __construct($name){
            $this->name = $name;
        }

        function __toString() {
            return "<tr><td><a href='genre-page.php?link_genre=".$this->name."'>" . $this->name. '</a></td></tr>';
        }
    }
 
?>