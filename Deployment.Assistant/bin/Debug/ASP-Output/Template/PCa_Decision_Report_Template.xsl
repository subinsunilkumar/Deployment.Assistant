<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html lang="en">
      <head>
        <title>Decision Report</title>
        <meta charset="utf-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>

        <style>
          .report-header {
          font-size: 10.5pt;
          font-weight: bold;
          line-height: 32px;
          color: #231F20;
          font-family: "Siemens Sans";
          font-style: normal;
          font-weight: bold;
          text-decoration: none;

          /*font-size: 10.5pt;*/
          }
          .report-headerinfo{
          font-weight: bold;
          font-style: normal;
          font-weight: bold;
          text-decoration: none;
          }
          .patientinfo-title {
          font-size: 12px;
          font-weight: bold;
          margin: 0px;
          color: #808285;
          font-family: "Siemens Sans";
          font-style: normal;
          font-weight: normal;
          text-decoration: none;
          font-size: 8pt;
          /*padding-top: 6pt;*/
          text-indent: 0pt;
          text-align: left;
          }

          .patientinfo-value {
          font-size: 16px;
          color: #000;
          margin: 6px 0px;
          color: #231F20;
          font-family: "Siemens Sans";
          font-style: normal;
          font-weight: normal;
          text-decoration: none;
          font-size: 10pt;
          margin: 0pt;
          }
          .ids-values {
          border-left: 2px solid #EC6602;
          padding-left: 20px;
          margin-left: 10px;
          }
          .ids-headers {
          border-left: 10px solid #EC6602;


          }

        </style>
      </head>
      <body>
        <table class="row" style="width:100%;">
          <tr>
            <td></td>
            <td style="max-width:100px !important; overflow:hidden;">
              <img style="width:200px;height:100px" src="/nfspersistent/DecisionReport/Template/HospitalLogo.jpg" alt="Hospital Logo" />
            </td>
            <td>
              <p></p>
            </td>
            <td style="width:50%;padding-left:10px;">
              <div width="100%"  style="text-align:left;">
                  <p class="report-headerinfo">
                    <xsl:value-of select="substring-before(Report/title, '|')"/>
                  </p>
                  <p class="report-headerinfo">
                    <xsl:value-of select="substring-after(Report/title, '|')"/>
                  </p>
              </div>
            </td>
            <td></td>
          </tr>

        </table>
        <br />
        <table style="width:100%;" valign="top">
          <tr>
            <td></td>
            <td style="width:50%;">
              <table>
                  <xsl:for-each select="Report/section[(title = 'Patient Info') or (title = 'Decision Info')]">
                    <tr width="98%">
                        <td class="report-header">
                            <xsl:value-of select="title"/>
                        </td>
                    </tr>
                    <xsl:for-each select="section">
                        <tr>
                            <td>
                                <div class="patientinfo-title">
                                    <xsl:value-of select="title"/>
                                </div>
                                <div class="patientinfo-value">
                                    <xsl:value-of select="text/div"/>
                                </div>
                            </td>
                        </tr>
                    </xsl:for-each>
                    <br />
                  </xsl:for-each>
              </table>
            </td>

            <td style="border-left:0.1pt solid; height:100%;width:4%;vertical-align: top;">
            </td>

            <td >
              <div style="padding-left:20px">
                <table style="border:1pt solid black !important;">
                  <xsl:for-each select="Report/section[(title != 'Patient Info') and (title != 'Decision Info')]">
                    <tr width="98%">
                        <td class="report-header">
                            <div class="ids-headers" style="display:inline;" >
                                <xsl:value-of select="title"/>
                            </div>
                            <br/>
                        </td>
                    </tr>
                    <xsl:for-each select="section">
                        <tr>
                            <td>
                                <div class="ids-values">
                                    <div class="patientinfo-title">
                                        <xsl:value-of select="title"/>
                                    </div>
                                    <div class="patientinfo-value">
                                        <xsl:value-of select="text/div"/>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr style="height:6pt;"></tr>
                    </xsl:for-each>
                    <br/>
                    <br/>
                  </xsl:for-each>
                </table>
              </div>
            </td>
            <td></td>
          </tr>
        </table>


      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>

