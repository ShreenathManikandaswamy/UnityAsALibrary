//
//  AppDelegate.swift
//  SwiftUnity
//
//  Created by Shreenath M on 25/09/23.
//

import UIKit

@main
class AppDelegate: UIResponder, UIApplicationDelegate {

    var window: UIWindow?

    func application(_ application: UIApplication, didFinishLaunchingWithOptions launchOptions: [UIApplication.LaunchOptionsKey: Any]?) -> Bool {

        Unity.shared.setHostMainWindow(window)

        return true
    }
}

