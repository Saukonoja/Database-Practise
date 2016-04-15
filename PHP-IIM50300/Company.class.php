<?php
 
    class Company{
        private $name;
        private $country;
        private $year;
 
        function __construct($name, $country, $year){
            $this->name = $name;
            $this->country = $country;
            $this->year = $year;         
        }

        function __toString() {
            return "<tr><td><a href='company-page.php?link_company=".$this->name."'>" . $this->name. '</a></td><td>'.$this->country.'</td><td>'.$this->year.'</td></tr>';
        }
    }
 
?>