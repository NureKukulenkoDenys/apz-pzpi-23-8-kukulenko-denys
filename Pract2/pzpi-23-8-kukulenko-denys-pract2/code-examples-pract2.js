const express = require('express');
const axios = require('axios');

const app = express();

app.get('/music/:userId', async (req, res) => {
  try {
    const response = await axios.get(`http://recommendation-service/${req.params.userId}`);
    res.json(response.data);
  } catch (error) {
    res.json({
      fallback: true,
      data: ["Популярний трек 1", "Популярний трек 2"]
    });
  }
});

app.listen(3000, () => console.log("Service running"));
