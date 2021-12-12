using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace XamarinPrism.src._11_Api.Models
{
    public class MakeUp
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public object PriceSign { get; set; }
        public object Currency { get; set; }

        //[JsonPropertyName("image_link")]
        [JsonConverter(typeof(ImageLinkConverter))]
        public string ImageLink { get; set; }
        public string ProductLink { get; set; }
        public string WebsiteLink { get; set; }
        public string Description { get; set; }
        public double? Rating { get; set; }
        public string Category { get; set; }
        [JsonPropertyName("product_type")]
        public string ProductType { get; set; }
        public List<object> TagList { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string ProductApiUrl { get; set; }
        public string ApiFeaturedImage { get; set; }
        public List<ProductColor> ProductColors { get; set; }

        public MakeUp()
        {

        }
    }

    public class ProductColor
    {
        public string HexValue { get; set; }
        public string ColourName { get; set; }
    }
    public class ImageLinkConverter : JsonConverter<string>
    {
        public override bool HandleNull => true;
        public override string Read(ref Utf8JsonReader reader, 
            Type typeToConvert, 
            JsonSerializerOptions options)
        {
            if(String.IsNullOrEmpty(reader.GetString()))
                return  "Hello link";
            return reader.GetString();
        }

        public override void Write(Utf8JsonWriter writer, 
            string value, 
            JsonSerializerOptions options)
        {
             writer.WriteStringValue(value);
        }
    }
}
