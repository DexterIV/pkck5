<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>

    <xsl:template match="/TwitchTV">
        <xsl:variable name="width" select="900"/>
        <xsl:variable name="height" select="900"/>
        <svg xmlns="http://www.w3.org/2000/svg" width="{$width}" height="{$height}">
            <style>
                text.outlined {
                    fill: white;
                    stroke: black;
                    font-family: sans-serif;
                    font-weight: bold;
                }
            </style>
            <defs>
                <linearGradient id="gradientBackground" x1="0%" y1="0%" x2="100%" y2="100%">
                    <stop offset="0%" stop-color="#99c3ff" stop-opacity="1">
                        <!--<animate attributeName="stop-opacity" from="0" to="1" dur="3s"/>-->
                    </stop>
                    <stop offset="100%" stop-color="#ff99de" stop-opacity="1">
                        <!--<animate attributeName="stop-opacity" from="0" to="1" dur="3s"/>-->
                    </stop>
                    <animate attributeName="x1" values="0%;100%;100%;0%;0%" dur="4s" repeatCount="indefinite"/>
                    <animate attributeName="y1" values="0%;0%;100%;100%;0%" dur="4s" repeatCount="indefinite"/>
                    <animate attributeName="x2" values="100%;0%;0%;100%;100%" dur="4s" repeatCount="indefinite"/>
                    <animate attributeName="y2" values="100%;100%;0%;0%;100%" dur="4s" repeatCount="indefinite"/>
                </linearGradient>
            </defs>
            <script href="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"/>
            <script type="text/javascript">
                function resize(id) {
                    let img = $('#'+id)
                    if(img.attr('resized')==='true'){
                        img.attr('width', '36')
                        img.attr('height', '36')
                        img.attr('x', parseInt(img.attr('x'))+18)
                        img.attr('y', parseInt(img.attr('y'))+18)
                        img.attr('resized', 'false')
                    }else{
                        img.attr('width', '72')
                        img.attr('height', '72')
                        img.attr('x', img.attr('x')-18)
                        img.attr('y', img.attr('y')-18)
                        img.attr('resized', 'true')
                    }
                }
            </script>
            <rect width="100%" height="100%" fill="url(#gradientBackground)"/>

            <text class="outlined" x="70" y="40" font-size="30">
                Autorzy:
            </text>
            <xsl:for-each select="Autorzy/Autor">
                <xsl:variable name="posY" select="25 * position() + 40"/>
                <text class="outlined" x="85" y="{$posY}" font-size="24">
                    <xsl:value-of select="concat(./Imię, ' ', ./Nazwisko)"/>
                </text>
            </xsl:for-each>
            <xsl:for-each select="Gra">
                <xsl:variable name="posY" select="180 * (position()-1) + 120"/>
                <xsl:variable name="image">
                    <xsl:choose>
                        <xsl:when test="./@Nazwa='Counter Strike Global Offensive'">csgo.png</xsl:when>
                        <xsl:when test="./@Nazwa='League of Legends'">lol.png</xsl:when>
                        <xsl:when test="./@Nazwa='GTA V'">gta.png</xsl:when>
                    </xsl:choose>
                </xsl:variable>
                <rect x="10%" y="{$posY}" width="80%" height="40" fill="white"/>
                <text x="50%" y="{$posY+28}" font-size="24" fill="black" text-anchor="middle">
                    <xsl:value-of select="./@Nazwa"/>
                </text>
                <image id="{substring-before($image, '.')}" href="{$image}" height="36" width="36" x="{0.85*$width}" y="{$posY+2}" onclick="resize(this.id)">
                    <xsl:variable name="resized" select="'false'"/>
                </image>

                <g id="table" transform="translate(100, 60)" text-anchor="middle">
                    <text x="100" y="{$posY}" font-size="18px" font-weight="bold" fill="crimson">
                        <tspan x="200">Nazwa</tspan>
                        <tspan x="330">Język</tspan>
                        <tspan x="440">Czas istnienia</tspan>
                        <tspan x="560">Podmiot</tspan>
                    </text>

                    <xsl:for-each select="./Kanał">
                        <text x="100" y="{$posY}" font-size="18px">
                            <tspan x="100" dy="{concat(position(), '.5em')}" font-weight="bold" fill="crimson" text-anchor="start">
                                <xsl:value-of select="position()"/>
                            </tspan>
                            <tspan x="200">
                                <xsl:value-of select="./Twórca/Nazwa"/>
                            </tspan>
                            <tspan x="330">
                                <xsl:value-of select="substring-after(./Język, ': ')"/>
                            </tspan>
                            <tspan x="440">
                                <xsl:value-of select="concat(./DługośćIstnieniaKanału, ' dni')"/>
                            </tspan>
                            <tspan x="560">
                                <xsl:value-of select="./Podmiot"/>
                            </tspan>
                        </text>
                    </xsl:for-each>
                </g>
            </xsl:for-each>
            <text class="outlined" x="70" y="680" font-size="26">
                Podsumowanie:
            </text>
            <text class="outlined" x="85" y="700" font-size="20">
                Kanały:
            </text>
            <xsl:for-each select="./Podsumowanie/Statystyki/Kanały/*">
                <text x="100" y="{700+position()*20}" font-size="14">
                    <xsl:value-of select="name(.)"/>
                </text>
                <text x="220" y="{700+position()*20}" font-size="14">
                    <xsl:value-of select="./text()"/>
                </text>
            </xsl:for-each>
            <text class="outlined" x="85" y="780" font-size="20">
                Gry:
            </text>
            <xsl:for-each select="./Podsumowanie/Statystyki/Gry/*">
                <text x="100" y="{780+position()*20}" font-size="14">
                    <xsl:value-of select="name(.)"/>
                </text>
                <text x="220" y="{780+position()*20}" font-size="14">
                    <xsl:value-of select="./text()"/>
                </text>
            </xsl:for-each>
        </svg>
    </xsl:template>
</xsl:stylesheet>