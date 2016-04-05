<?php
 
    class ArtistView{
        private $album;
        private $year;
        private $company;
 
        function __construct($album, $year, $company){
            $this->album = $album;
            $this->year = $year;
            $this->company = $company;
        }

        function __toString() {
            return "<tr><td><a href='album-page.php?link_album=".$this->album."'>" . $this->album. '</td><td>' . $this->year. '</td><td>'. $this->company . '</td></tr>';
        }
    }
 
?>