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
            return "<tr><td><a href='album-page.php?link_album=".$this->album."'>" . $this->album. "</a></td><td id=year>" . $this->year. "</td>
                        <td><a href='company-page.php?link_company=".$this->company."'>". $this->company . "</a></td></tr>";
        }
    }
 
?>