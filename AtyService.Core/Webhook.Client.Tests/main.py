
from logging import debug
from flask import Flask, request, json
import requests

host='127.0.0.1'

def setupwebhook():
    setup_data = {  }
    requests.post(url_setup, json=setup_data)

app = Flask(__name__)

@app.route("/getnotification", methods=['POST'])
def getnotification():
    data = request.args.get('data', default=1, type=any)
    print(data)
    return json.jsonify(data)

if __name__ == '__main__':
    #setupwebhook()
    app.run(host=host, port=5050, debug=True)
