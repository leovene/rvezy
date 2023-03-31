using System;
using CsvHelper;
using RVezy.WebAPI.Domain.Models;

namespace RVezy.WebAPI.Services
{
	public class CSVParseService
	{
		public IList<ListingModel> ToListingModel(string csvFilePath)
		{
            using var streamReader = new StreamReader(csvFilePath);
            using var csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.InvariantCulture);

            var result = csvReader.GetRecords<ListingModel>().ToList();

			return result;
        }

        public IList<CalendarModel> ToCalendarModel(string csvFilePath)
        {
            using var streamReader = new StreamReader(csvFilePath);
            using var csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.InvariantCulture);

            var result = csvReader.GetRecords<CalendarModel>().ToList();

            return result;
        }

        public IList<ReviewModel> ToReviewModel(string csvFilePath)
        {
            using var streamReader = new StreamReader(csvFilePath);
            using var csvReader = new CsvReader(streamReader, System.Globalization.CultureInfo.InvariantCulture);

            var result = csvReader.GetRecords<ReviewModel>().ToList();

            return result;
        }
    }
}

