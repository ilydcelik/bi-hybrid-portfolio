# KPI Definitions

Aşağıdaki KPI’lar örnek dummy dataset (sales_data.csv) için tanımlanmıştır.

| KPI | Tanım | Formül / Mantık (SQL) | Not |
|---|---|---|---|
| Total Sales | Toplam satış tutarı | `SELECT SUM(Amount) FROM dwh.FactSales;` | Para birimi: ₺ (dummy) |
| Sales by Region | Bölge bazında satış | `SELECT Region, SUM(Amount) FROM dwh.FactSales GROUP BY Region;` | Harita/çubuk grafik |
| Top Products | Ürün bazında satış sıralaması | `SELECT ProductName, SUM(Amount) AS SalesValue FROM dwh.FactSales GROUP BY ProductName ORDER BY SalesValue DESC;` | İlk 10 |
| Price per KG | KG başına fiyat | `SUM(Amount) / NULLIF(SUM(QuantityKG),0)` | Ağırlık metrikleri |
| Price per TON | Ton başına fiyat | `SUM(Amount) / NULLIF(SUM(QuantityTON),0)` | Ağırlık metrikleri |
| YoY Growth | Yıllık büyüme | `(SalesYearN - SalesYearN-1) / SalesYearN-1` | Zaman serisi |
| Gross Margin (dummy) | Brüt kâr (varsayımsal) | `SUM(Amount) - SUM(EstimatedCost)` | EstimatedCost tahmini kolon |
| Conversion Rate (dummy) | Teklif→Satış dönüşümü | `WonOpportunities / Opportunities` | Eğer CRM datası varsa |

## Veri Sözlüğü (özet)
- **Amount:** Satış tutarı (dummy)
- **QuantityKG / QuantityTON:** Ağırlık metrikleri
- **Region / ProductCategory / ProductName / CustomerType:** Boyutlar
