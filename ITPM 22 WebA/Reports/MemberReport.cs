using iTextSharp.text;
using iTextSharp.text.pdf;
using ITPM_22_WebA.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ITPM_22_WebA.Reports
{
    public class MemberReport
    {
        private IWebHostEnvironment _oHostEnvironment;

        public MemberReport(IWebHostEnvironment oHostEnvironment)
        {
            _oHostEnvironment = oHostEnvironment;
        }


        #region Declaration
        int _maxColumn = 5;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(5);
        MemoryStream _memoryStream = new MemoryStream();

        List<NewMemberClass> _oMembers = new List<NewMemberClass>();

        #endregion

        public byte[] Report(List<NewMemberClass> oMembers)
        {

            _oMembers = oMembers;

            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(5f, 5f, 20f, 5f);

            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter docwrite = PdfWriter.GetInstance(_document, _memoryStream);

            _document.Open();

            float[] sizes = new float[_maxColumn];
            for (var i = 0; i< _maxColumn; i++)
            {
                if (i == 0) sizes[i] = 20;
                else sizes[i] = 100;

            }

            _pdfTable.SetWidths(sizes);

            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);

            _document
        }

    }
}
