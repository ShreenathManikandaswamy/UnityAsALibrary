//
//  ContentView.swift
//  SwiftUnity
//
//  Created by Shreenath M on 25/09/23.
//

import SwiftUI

private struct ButtonViewModifier: ViewModifier {
    var color: Color

    func body(content: Content) -> some View {
        content.frame(width: 200, height: 50).background(color)
    }
}

private struct TextViewModifier: ViewModifier {
    func body(content: Content) -> some View {
        content.font(.title).foregroundColor(Color.white)
    }
}

struct ContentView: View {
    var body: some View {
        VStack {
            Spacer()

            Button(action: {
                Unity.shared.show()
                Unity.shared.sendMessage(
                    "IntentReceiver",
                    methodName: "SetBrand",
                    message: "Jeep"
                )
            }) {
                Text("Jeep").modifier(TextViewModifier())
            }
            .modifier(ButtonViewModifier(color: Color.red))

            Spacer()

            Button(action: {
                Unity.shared.show()
                Unity.shared.sendMessage(
                    "IntentReceiver",
                    methodName: "SetBrand",
                    message: "Lancia"
                )
            }) {
                Text("Lancia").modifier(TextViewModifier())
            }
            .modifier(ButtonViewModifier(color: Color.blue))
            
            Spacer()
        }
    }
}
