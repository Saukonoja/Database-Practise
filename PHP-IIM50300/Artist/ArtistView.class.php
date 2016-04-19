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
            include ('../Init/config.php');
            return "<tr><td><a href='" . $albumPage . "?link_album=".$this->album."'>" . $this->album. "</a></td><td id=year>" . $this->year. "</td>
                        <td><a href='" . $companyPage . "?link_company=".$this->company."'>". $this->company . "</a></td></tr>";
        }
    }
 
?>